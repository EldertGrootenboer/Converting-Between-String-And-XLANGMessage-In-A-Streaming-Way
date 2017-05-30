using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using Microsoft.BizTalk.Streaming;
using Microsoft.XLANGs.BaseTypes;
using Microsoft.XLANGs.Core;

namespace ConvertingBetweenStringAndXLANGMessage.Helpers
{
    public class XLangMessageHelpers
    {
        /// <summary>
        /// Create an XLANGMessage from a dictionary of strings.
        /// </summary>
        public static XLANGMessage CreateXLANGMessageFromString(string message, string messagePartName)
        {
            // The BTX message used to create the XLANGMessage later on
            var customBTXMessage = CreateMessagePart(message, messagePartName, null, 0);

            // Return the XLANGMessage
            return customBTXMessage.GetMessageWrapperForUserCode();
        }

        /// <summary>
        /// Create an XLANGMessage from a dictionary of strings.
        /// </summary>
        public static XLANGMessage CreateXLANGMessageFromString(ArrayList messages)
        {
            // The BTX message used to create the XLANGMessage later on
            CustomBTXMessage customBTXMessage = null;

            // Indexer
            var index = 0;

            // Loop through the messages for which we want to create a message part
            foreach (var message in messages.OfType<MessagePart>())
            {
                customBTXMessage = CreateMessagePart(message.Message, message.MessagePartName, customBTXMessage, index);

                // Next index for following message
                index++;
            }

            // Return the XLANGMessage
            return customBTXMessage.GetMessageWrapperForUserCode();
        }
        
        /// <summary>
        /// Add a part from a string to an existing XLANGMessage.
        /// </summary>
        public static XLANGMessage AddMessagePartFromString(XLANGMessage xlangMessage, string message, string messagePartName)
        {
            // Create a list which will hold the message parts for the new XLANGMessage
            var existingMessageParts = new ArrayList();

            // Loop through the message parts of the existing XLANGMessage
            foreach (XLANGPart messagePart in xlangMessage)
            {
                // Get the name of the message part
                var name = messagePart.Name;

                // Get the contents of this part as a string
                var messagePartAsString = CreateStringFromXLANGMessage(xlangMessage, name);

                // Add part to the list
                existingMessageParts.Add(new MessagePart(messagePartAsString, name));
            }

            // Add new message part to the list
            existingMessageParts.Add(new MessagePart(message, messagePartName));

            // Create a new XLANGMessage with the new message part added
            return CreateXLANGMessageFromString(existingMessageParts);
        }

        /// <summary>
        /// Create a new message part in the supplied CustomBTXMessage.
        /// </summary>
        private static CustomBTXMessage CreateMessagePart(string message, string messagePartName, CustomBTXMessage customBTXMessage, int index)
        {
            // Create a VirtualStream for memory optimization
            const int bufferSize = 640;
            const int thresholdSize = 1048576; // 1MB
            var stream = new VirtualStream(bufferSize, thresholdSize);

            // Make sure booleans are in lowercasing, or we could get exceptions in BizTalk if this is a promoted property / distinguished field
            message = message.Replace("True", "true").Replace("False", "false");

            // Create a reader which will be used to read through the message
            using (var reader = new XmlTextReader(new StringReader(message)))
            {
                // Create a writer used to write the outgoing message
                using (var writer = XmlWriter.Create(stream, new XmlWriterSettings { ConformanceLevel = ConformanceLevel.Auto, Encoding = Encoding.UTF8 }))
                {
                    // Read through the message
                    while (reader.Read())
                    {
                        // Once we know the rootnode name, we can create the BTX message
                        if (customBTXMessage == null && reader.NodeType == XmlNodeType.Element)
                        {
                            // Create a CustomBTXMessage, which will be used to create our XLANGMessage
                            customBTXMessage = new CustomBTXMessage(reader.LocalName, Service.RootService.XlangStore.OwningContext);
                        }

                        // Write the current element
                        writer.WriteNode(reader, true);
                    }
                }
            }

            // Reset the stream
            stream.Seek(0, SeekOrigin.Begin);

            // Add message part
            customBTXMessage.AddPart(string.Empty, messagePartName);

            // Load the message we just created
            customBTXMessage[index].LoadFrom(stream);

            return customBTXMessage;
        }

        /// <summary>
        /// Create a string from a XLANGMessage.
        /// </summary>
        public static string CreateStringFromXLANGMessage(XLANGMessage message, int index)
        {
            // The string to be returned
            string toReturn;

            try
            {
                // Get the message part as a Stream and create a reader which will read in the stream
                using (var reader = new StreamReader(message[index].RetrieveAs(typeof(Stream)) as Stream))
                {
                    // Read in the message
                    toReturn = reader.ReadToEnd();
                }
            }
            finally
            {
                // Clean memory
                message.Dispose();
            }

            // Return the result
            return toReturn;
        }

        /// <summary>
        /// Create a string from a XLANGMessage.
        /// </summary>
        public static string CreateStringFromXLANGMessage(XLANGMessage message, string name)
        {
            // The string to be returned
            string toReturn;

            try
            {
                // Get the message part as a Stream and create a reader which will read in the stream
                using (var reader = new StreamReader(message[name].RetrieveAs(typeof(Stream)) as Stream))
                {
                    // Read in the message
                    toReturn = reader.ReadToEnd();
                }
            }
            finally
            {
                // Clean memory
                message.Dispose();
            }

            // Return the result
            return toReturn;
        }
    }
}

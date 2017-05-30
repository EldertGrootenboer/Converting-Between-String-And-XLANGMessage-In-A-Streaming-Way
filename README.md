# Converting Between String And XLANGMessage In A Streaming Way
Often when we want to create a message in an orchestration from a message assignment shape, the option of using an XMLDocument is chosen. However, this option can be a serious performance hit, as your entire message will be loaded into memory, and can become as large as 10 times it’s original size. To avoid these performance hits, it would be better to work with XLangMessage directly, BizTalk’s native messages, instead of an XMLDocument, and create the message in a streaming way. This way you can simply create a message from a string (and the other way around).

## Create XLANGMessage from string
We will be creating a helper class which can be used to convert your messages between String and XLANGMessage. We will use a VirtualStream combined with a XmlTextReader and XmlWriterfor optimal performance. Once the message has been loaded into the XmlWriter’s stream, we use it to create a custom BTXMessage. This way, we can directly assign our message to a message in a BizTalk Message Assignment shape.
First we will create the CustomBTXMessage class, which is our own implementation of a BTXMessage. Using this class we will be able to create our own XLANGMessage objects. We will need to add a reference to the Microsoft.XLANGs.BizTalk.Engine assembly for this.

```C#
[Serializable] 
internal sealed class CustomBTXMessage : BTXMessage 
{ 
    public CustomBTXMessage(string messageName, Context context) 
        : base(messageName, context) 
    { 
        context.RefMessage(this); 
    } 
} 
```

Now that we have our own BTXMessage class in place, let's create a new class with a method which will create a CustomBTXMessage from a string. As we will be using a VirtualStream here, we will need to reference the [Microsoft.BizTalk.Streaming](https://msdn.microsoft.com/en-US/library/Microsoft.BizTalk.Streaming.aspx) assembly in our project. We will also need references to the Microsoft.XLANGs.Engine and [Microsoft.XLANGs.BaseTypes](https://msdn.microsoft.com/en-US/library/Microsoft.XLANGs.BaseTypes.aspx) assemblies for working with our custom BTXMessage. This is also the class where we can do transformations on our xml.

```C#
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
```

We now can create our custom BTXMessage from a string, next step is to use this to create a XLANGMessage. We can use the GetMessageWrapperForUserCode method for this, which will convert our BTXMessage with all it's parts into a XLangMessage.

```C#
public static XLANGMessage CreateXLANGMessageFromString(string message, string messagePartName) 
{ 
    // The BTX message used to create the XLANGMessage later on 
    var customBTXMessage = CreateMessagePart(message, messagePartName, null, 0); 
 
    // Return the XLANGMessage 
    return customBTXMessage.GetMessageWrapperForUserCode(); 
}
```

### Create multipart XLANGMessage from strings
One of the strong suits of BizTalk is the possibility to use multipart messages, so off course we will also want to be able to create these. We will use a new MessagePart class to hold the data for this.

```C#
[Serializable] 
public class MessagePart 
{ 
    public string Message { get; set; } 
 
    public string MessagePartName { get; set; } 
 
    public MessagePart(string message, string messagePartName) 
    { 
        Message = message; 
        MessagePartName = messagePartName; 
    } 
} 
```

Next we will create a method which will accept an array of these MessageParts, and will use these to create a BTXMessage with all these parts.

```C#
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
```

## Create string from XLANGMessage
Now that we can convert a string to an XLangMessage, let’s also implement the reverse. This can come in handy when you, for example, want to output the contents of message in a tracing statement, or if you need to contents for another reason. We will also use this later on to add messageparts to an existing XLANGMessage.

```C#
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
```

Once again, we use a streaming approach to optimize performance. Other then that, it’s a very straightforward implementation, you just need to make sure you provide the correct index for the messagepart you want to retrieve in the message. For the indexer, you can use the integral index as we showed here, or a string with the name of the messagepart.

## Add new part to XLANGMessage
Finally, we will use the implementation we did above to add a new part to an existing message. This can come in handy if for example you would like to add a routing or BAM part to an existing message.

```C#
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
```
 
Now that we have our library in place, we can use this from an orchestration to create messages from our code in a streaming manner, without the need for an XMLDocument.

![](https://code.msdn.microsoft.com/site/view/file/148249/1/OrchestrationWithXLANGMessageFromString.PNG)

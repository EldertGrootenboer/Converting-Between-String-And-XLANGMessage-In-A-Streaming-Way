using System;

namespace ConvertingBetweenStringAndXLANGMessage.Helpers
{
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
}

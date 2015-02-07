using System;

namespace DroneStudio.ApplicationLogic.Messages
{
    public class FloatValueMessageParser : IMessageParser
    {
        public IMessage TryParse(string line)
        {
            try
            {
                var elements = line.Split(' ');

                if (!elements[0].Equals(MessageHeader)) return null;;

                int offset = int.Parse(elements[1]);

                float value = float.Parse(elements[2]);

                return new FloatValueMessage(offset, value);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private const string MessageHeader = "FV";
    }
}

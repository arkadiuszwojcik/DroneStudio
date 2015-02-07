using System;

namespace DroneStudio.ApplicationLogic.Messages
{
    public class ShortValueMessageParser : IMessageParser
    {
        public IMessage TryParse(string line)
        {
            try
            {
                var elements = line.Split(' ');

                if (!elements[0].Equals(MessageHeader)) return null; ;

                int offset = int.Parse(elements[1]);

                short value = short.Parse(elements[2]);

                return new ShortValueMessage(offset, value);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private const string MessageHeader = "SV";
    }
}

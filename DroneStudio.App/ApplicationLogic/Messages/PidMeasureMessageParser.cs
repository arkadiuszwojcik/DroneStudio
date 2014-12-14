using System;

namespace DroneStudio.ApplicationLogic.Messages
{
    public class PidMeasureMessageParser : IMessageParser
    {
        public IMessage TryParse(string line)
        {
            if (string.IsNullOrWhiteSpace(line)) return null;

            var elements = line.Split(' ');

            if (!(elements.Length > 1 && elements[0].Equals(MessageHeader))) return null;

            int value;

            if (!Int32.TryParse(elements[1], out value)) return null;

            return new PidMeasureMessage(value);
        }

        private const string MessageHeader = "PIDM";
    }
}

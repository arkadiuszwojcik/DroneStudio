using System;

namespace DroneStudio.ApplicationLogic.Messages
{
    public class ReceivedPidMessageParser : IMessageParser
    {
        public IMessage TryParse(string line)
        {
            try 
            {
                var elements = line.Split(' ');

                if (!elements[0].Equals(MessageHeader)) return null;

                PidType pidType = elements[1].ToPidType();

                float p = float.Parse(elements[2]);
                float i = float.Parse(elements[3]);
                float d = float.Parse(elements[4]);
                float maxI = float.Parse(elements[5]);

                return new ReceivedPidMessage(pidType, p, i, d, maxI);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private const string MessageHeader = "PID";
    }
}

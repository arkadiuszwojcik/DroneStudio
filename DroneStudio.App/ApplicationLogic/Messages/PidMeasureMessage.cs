using System;
namespace DroneStudio.ApplicationLogic.Messages
{
    public class PidMeasureMessage : IMessage
    {
        public PidMeasureMessage(int value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", MessageHeader, this.value);
        }

        public int Value { get { return this.value; } }

        private readonly int value;

        private const string MessageHeader = "PIDM";
    }
}

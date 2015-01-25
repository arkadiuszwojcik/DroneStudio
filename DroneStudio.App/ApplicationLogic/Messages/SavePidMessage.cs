using System;

namespace DroneStudio.ApplicationLogic.Messages
{
    public class SavePidMessage : IMessage
    {
        public SavePidMessage(PidType pidType, float p, float i, float d, float maxI)
        {
            this.pidType = pidType;
            this.p = p;
            this.i = i;
            this.d = d;
            this.maxI = maxI;
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2:0.0000} {3:0.0000} {4:0.0000} {5:0.0000}\n",
                MessageHeader, this.pidType.FormatToString(), this.p, this.i, this.d, this.maxI);
        }

        private readonly PidType pidType;
        private readonly float p;
        private readonly float i;
        private readonly float d;
        private readonly float maxI;

        private const string MessageHeader = "SETPID";
    }
}

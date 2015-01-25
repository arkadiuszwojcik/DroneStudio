namespace DroneStudio.ApplicationLogic.Messages
{
    public class ReceivedPidMessage : IMessage
    {
        public ReceivedPidMessage(PidType pidType, float p, float i, float d, float maxI)
        {
            this.pidType = pidType;
            this.p = p;
            this.i = i;
            this.d = d;
            this.maxI = maxI;
        }

        public PidType PidType { get { return this.pidType; } }

        public float P { get { return this.p; } }

        public float I { get { return this.i; } }

        public float D { get { return this.d; } }

        public float MaxI { get { return this.maxI; } }

        private readonly PidType pidType;
        private readonly float p;
        private readonly float i;
        private readonly float d;
        private readonly float maxI;
    }
}

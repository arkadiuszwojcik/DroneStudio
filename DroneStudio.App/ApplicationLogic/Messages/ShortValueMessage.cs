using System;

namespace DroneStudio.ApplicationLogic.Messages
{
    public class ShortValueMessage : IMessage
    {
        public ShortValueMessage(int offset, short value)
        {
            this.offset = offset;
            this.value = value;
        }

        public override string ToString()
        {
            return String.Format("SS {0} {1}\n", this.offset, this.value);
        }

        public int Offset { get { return this.offset; } }

        public short Value { get { return this.value; } }

        private readonly int offset;

        private readonly short value;
    }
}

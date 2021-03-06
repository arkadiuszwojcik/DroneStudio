﻿using System;

namespace DroneStudio.ApplicationLogic.Messages
{
    public class FloatValueMessage : IMessage
    {
        public FloatValueMessage(int offset, float value)
        {
            this.offset = offset;
            this.value = value;
        }

        public override string ToString()
        {
            return String.Format("SF {0} {1}\n", this.offset, this.value);
        }

        public int Offset { get { return this.offset; } }

        public float Value { get { return this.value; } }

        private readonly int offset;

        private readonly float value;
    }
}

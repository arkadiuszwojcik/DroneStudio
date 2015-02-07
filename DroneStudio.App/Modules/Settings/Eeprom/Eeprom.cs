using System;
using System.Threading;
using System.Reactive.Linq;
using DroneStudio.Library;
using DroneStudio.ApplicationLogic;
using DroneStudio.ApplicationLogic.Messages;

namespace DroneStudio.Modules.Settings.Eeprom
{
    public class Eeprom<T> where T : struct
    {
        public Eeprom()
        {
            this.lockSlim = new ReaderWriterLockSlim();
            this.byteEeprom = StructSerializer.StructureToByteArray(this.eeprom);
        }

        public void WriteFloat(int offset, float value)
        {
            this.lockSlim.EnterWriteLock();
            try
            {
                Array.Copy(BitConverter.GetBytes(value), 0, this.byteEeprom, offset, 4);
            }
            finally
            {
                this.lockSlim.ExitWriteLock();
            }
        }

        public void WriteShort(int offset, short value)
        {
            this.lockSlim.EnterWriteLock();
            try
            {
                Array.Copy(BitConverter.GetBytes(value), 0, this.byteEeprom, offset, 2);
            }
            finally
            {
                this.lockSlim.ExitWriteLock();
            }
        }

        public float ReadFloat(int offset)
        {
            this.lockSlim.EnterReadLock();
            try
            {
                return BitConverter.ToSingle(this.byteEeprom, offset);
            }
            finally
            {
                this.lockSlim.ExitReadLock();
            }
        }

        public short ReadShort(int offset)
        {
            this.lockSlim.EnterReadLock();
            try
            {
                return BitConverter.ToInt16(this.byteEeprom, offset);
            }
            finally
            {
                this.lockSlim.ExitReadLock();
            }
        }

        private T eeprom;
        private byte[] byteEeprom;
        private readonly ReaderWriterLockSlim lockSlim;
    }
}

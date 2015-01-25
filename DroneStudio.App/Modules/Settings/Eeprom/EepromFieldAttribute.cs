using System;

namespace DroneStudio.Modules.Settings.Eeprom
{
    [AttributeUsage(AttributeTargets.Field)]
    public class EepromFieldAttribute : Attribute
    {
        public EepromFieldAttribute(int offset, Type type, string name)
        {
            this.FieldOffset = offset;
            this.FieldName = name;
            this.FieldType = type;
        }

        public int FieldOffset { get; private set; }

        public Type FieldType { get; private set; }

        public string FieldName { get; private set; }
    }
}

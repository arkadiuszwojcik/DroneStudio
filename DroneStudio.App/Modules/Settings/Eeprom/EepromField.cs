using System;

namespace DroneStudio.Modules.Settings.Eeprom
{
    public class EepromField
    {
        public EepromField(EepromFieldAttribute eepromFirldAttribute)
        {
            this.FieldOffset = eepromFirldAttribute.FieldOffset;
            this.FieldName = eepromFirldAttribute.FieldName;
            this.FieldType = eepromFirldAttribute.FieldType;
        }

        public int FieldOffset { get; private set; }

        public Type FieldType { get; private set; }

        public string FieldName { get; private set; }

        public bool Modyfied { get; set; }
    }
}

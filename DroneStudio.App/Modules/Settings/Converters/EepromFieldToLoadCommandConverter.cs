using System;
using DroneStudio.Modules.Settings.Eeprom;

namespace DroneStudio.Modules.Settings.Converters
{
    public class EepromFieldToLoadCommandConverter
    {
        public string ToCommand(EepromField eepromField)
        {
            string cmd = this.TypeToCommand(eepromField.FieldType);
            return string.Format("{0} {1}\n", cmd, eepromField.FieldOffset);
        }

        private string TypeToCommand(Type type)
        {
            return type == typeof(float) ? "GF" : "GS";
        }
    }
}

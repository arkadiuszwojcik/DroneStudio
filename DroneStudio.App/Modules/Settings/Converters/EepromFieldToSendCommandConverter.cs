using System;
using DroneStudio.Modules.Settings.Eeprom;

namespace DroneStudio.Modules.Settings.Converters
{
    public class EepromFieldToSendCommandConverter
    {
        public string ToCommand(ISettingsModel settingsModel, EepromField eepromField)
        {
            string command = this.TypeToCommand(eepromField.FieldType);
            string value = this.GetStringValue(settingsModel, eepromField);
            return string.Format("{0} {1} {2}\n", command, eepromField.FieldOffset, value);
        }

        private string TypeToCommand(Type type)
        {
            return type == typeof(float) ? "SF" : "SS";
        }

        private string GetStringValue(ISettingsModel settingsModel, EepromField eepromField)
        {
            if (eepromField.FieldType == typeof(float))
            {
                return settingsModel.GetFloat(eepromField).ToString("0.0000");
            }
            else
            {
                return settingsModel.GetShort(eepromField).ToString();
            }
        }
    }
}

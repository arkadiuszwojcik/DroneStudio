using DroneStudio.Modules.Settings.Eeprom;

namespace DroneStudio.Modules.Settings.ViewModels
{
    public class FieldViewModel
    {
        public FieldViewModel(EepromField eepromField, ISettingsModel settingsModel)
        {
            this.EepromField = eepromField;

            if (this.EepromField.FieldType == typeof(float))
                this.ValueViewModel = new FloatViewModel(eepromField, settingsModel);
            else if (this.EepromField.FieldType == typeof(short))
                this.ValueViewModel = new ShortViewModel(eepromField, settingsModel);
        }

        public EepromField EepromField { get; private set; }

        public object ValueViewModel { get; private set; }
    }
}

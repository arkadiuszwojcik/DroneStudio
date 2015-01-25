using DroneStudio.Modules.Settings.Eeprom;

namespace DroneStudio.Modules.Settings.ViewModels
{
    public class FieldViewModel
    {
        public FieldViewModel(EepromFieldAttribute fieldAttribute, ISettingsModel settingsModel)
        {
            this.FieldAttribute = fieldAttribute;

            if (this.FieldAttribute.FieldType == typeof(float))
                this.ValueViewModel = new FloatViewModel(fieldAttribute, settingsModel);
            else if (this.FieldAttribute.FieldType == typeof(short))
                this.ValueViewModel = new ShortViewModel(fieldAttribute, settingsModel);
        }

        public EepromFieldAttribute FieldAttribute { get; private set; }

        public object ValueViewModel { get; private set; }
    }
}

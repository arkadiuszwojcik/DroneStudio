using GalaSoft.MvvmLight;
using DroneStudio.Modules.Settings.Eeprom;

namespace DroneStudio.Modules.Settings.ViewModels
{
    public class ShortViewModel : ViewModelBase
    {
        public ShortViewModel(EepromField eepromField, ISettingsModel settingsModel)
        {
            this.settingsModel = settingsModel;
            this.eepromField = eepromField;
            settingsModel.EepromModyfied += OnModyfied;
        }

        public short Value 
        {
            get { return this.settingsModel.GetShort(eepromField); }
            set { this.settingsModel.SetShort(eepromField, value); }
        }

        private void OnModyfied(object sender, System.EventArgs e)
        {
            this.RaisePropertyChanged(string.Empty);
        }

        private readonly ISettingsModel settingsModel;
        private readonly EepromField eepromField;
    }
}

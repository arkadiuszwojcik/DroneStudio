using GalaSoft.MvvmLight;
using DroneStudio.Modules.Settings.Eeprom;

namespace DroneStudio.Modules.Settings.ViewModels
{
    public class FloatViewModel : ViewModelBase
    {
        public FloatViewModel(EepromField eepromField, ISettingsModel settingsModel)
        {
            this.settingsModel = settingsModel;
            this.eepromField = eepromField;
            settingsModel.EepromModyfied += OnModyfied;
        }

        public float Value 
        {
            get { return this.settingsModel.GetFloat(eepromField); }
            set { this.settingsModel.SetFloat(eepromField, value); }
        }

        private void OnModyfied(object sender, System.EventArgs e)
        {
            this.RaisePropertyChanged(string.Empty);
        }

        private readonly ISettingsModel settingsModel;
        private readonly EepromField eepromField;
    }
}

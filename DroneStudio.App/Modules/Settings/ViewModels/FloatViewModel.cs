using GalaSoft.MvvmLight;
using DroneStudio.Modules.Settings.Eeprom;

namespace DroneStudio.Modules.Settings.ViewModels
{
    public class FloatViewModel : ViewModelBase
    {
        public FloatViewModel(EepromFieldAttribute fieldAttribute, ISettingsModel settingsModel)
        {
            this.settingsModel = settingsModel;
            this.fieldAttribute = fieldAttribute;
            settingsModel.Modyfied += OnModyfied;
        }

        public float Value 
        {
            get { return this.settingsModel.GetFloat(fieldAttribute); }
            set { this.settingsModel.SetFloat(fieldAttribute, value); }
        }

        private void OnModyfied(object sender, System.EventArgs e)
        {
            this.RaisePropertyChanged(string.Empty);
        }

        private readonly ISettingsModel settingsModel;
        private readonly EepromFieldAttribute fieldAttribute;
    }
}

using GalaSoft.MvvmLight;
using DroneStudio.Modules.Settings.Eeprom;

namespace DroneStudio.Modules.Settings.ViewModels
{
    public class ShortViewModel : ViewModelBase
    {
        public ShortViewModel(EepromFieldAttribute fieldAttribute, ISettingsModel settingsModel)
        {
            this.settingsModel = settingsModel;
            this.fieldAttribute = fieldAttribute;
            settingsModel.Modyfied += OnModyfied;
        }

        public short Value 
        {
            get { return this.settingsModel.GetShort(fieldAttribute); }
            set { this.settingsModel.SetShort(fieldAttribute, value); }
        }

        private void OnModyfied(object sender, System.EventArgs e)
        {
            this.RaisePropertyChanged(string.Empty);
        }

        private readonly ISettingsModel settingsModel;
        private readonly EepromFieldAttribute fieldAttribute;
    }
}

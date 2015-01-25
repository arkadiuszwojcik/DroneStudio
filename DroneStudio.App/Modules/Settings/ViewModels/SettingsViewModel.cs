using System.Collections.ObjectModel;
using DroneStudio.Library;
using GalaSoft.MvvmLight;

namespace DroneStudio.Modules.Settings.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        public SettingsViewModel(ISettingsModel settingsModel)
        {
            this.settingsModel = settingsModel;
            this.Fields = new ObservableCollection<FieldViewModel>();

            this.settingsModel.EepromFields.ForEach(f => {
                    this.Fields.Add(new FieldViewModel(f, settingsModel)); 
                });
        }

        public ObservableCollection<FieldViewModel> Fields { get; private set; }

        private readonly ISettingsModel settingsModel;
    }
}

using System.Collections.ObjectModel;
using DroneStudio.Library.Extensions;
using GalaSoft.MvvmLight;
using DroneStudio.Modules.Settings.Commands;
using System.Windows.Input;

namespace DroneStudio.Modules.Settings.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        public SettingsViewModel(
            ISettingsModel settingsModel,
            LoadCommand loadCommand,
            SaveCommand saveCommand,
            SendCommand sendCommand)
        {
            this.settingsModel = settingsModel;

            this.Fields = new ObservableCollection<FieldViewModel>();
            this.LoadCommand = loadCommand;
            this.SaveCommand = saveCommand;
            this.SendCommand = sendCommand;

            this.settingsModel.EepromFields.ForEach(f => {
                    this.Fields.Add(new FieldViewModel(f, settingsModel)); 
                });
        }

        public ObservableCollection<FieldViewModel> Fields { get; private set; }

        public ICommand LoadCommand { get; private set; }

        public ICommand SaveCommand { get; private set; }

        public ICommand SendCommand { get; private set; }

        private readonly ISettingsModel settingsModel;
    }
}

using System;
using System.Windows.Input;
using DroneStudio.ApplicationLogic;
using DroneStudio.Modules.Settings.Converters;

namespace DroneStudio.Modules.Settings.Commands
{
    public class SendCommand : ICommand
    {
        public SendCommand(
            ISettingsModel settingsModel,
            ICommandLink commandLink,
            EepromFieldToSendCommandConverter fieldToCommandConverter)
        {
            this.settingsModel = settingsModel;
            this.commandLink = commandLink;
            this.fieldToCommandConverter = fieldToCommandConverter;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            foreach (var field in this.settingsModel.EepromFields)
            {
                if (!field.Modyfied) continue;

                string command = this.fieldToCommandConverter.ToCommand(this.settingsModel, field);
                this.commandLink.SendCommand(command);
                field.Modyfied = false;
            }
        }

        private readonly ISettingsModel settingsModel;
        private readonly ICommandLink commandLink;
        private readonly EepromFieldToSendCommandConverter fieldToCommandConverter;
    }
}

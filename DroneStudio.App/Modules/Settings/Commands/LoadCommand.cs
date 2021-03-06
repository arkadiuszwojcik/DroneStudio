﻿using System;
using System.Windows.Input;
using DroneStudio.ApplicationLogic;
using DroneStudio.Modules.Settings.Converters;
using DroneStudio.Modules.Settings.Eeprom;

namespace DroneStudio.Modules.Settings.Commands
{
    public class LoadCommand : ICommand
    {
        public LoadCommand(
            ISettingsModel settingsModel,
            ICommandLink commandLink,
            EepromFieldToLoadCommandConverter fieldToCommandConverter)
        {
            this.commandLink = commandLink;
            this.settingsModel = settingsModel;
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
                string command = this.fieldToCommandConverter.ToCommand(field);
                this.commandLink.SendCommand(command);
            }
        }

        private readonly ICommandLink commandLink;
        private readonly ISettingsModel settingsModel;
        private readonly EepromFieldToLoadCommandConverter fieldToCommandConverter;
    }
}

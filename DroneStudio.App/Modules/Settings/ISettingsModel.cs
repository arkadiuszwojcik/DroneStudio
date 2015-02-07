using System;
using System.Collections.Generic;
using DroneStudio.Modules.Settings.Eeprom;

namespace DroneStudio.Modules.Settings
{
    public interface ISettingsModel
    {
        void SetFloat(EepromField field, float value);
        float GetFloat(EepromField field);

        void SetShort(EepromField field, short value);
        short GetShort(EepromField field);

        IEnumerable<EepromField> EepromFields { get; }

        event EventHandler EepromModyfied;
    }
}

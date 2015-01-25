using System;
using System.Collections.Generic;
using DroneStudio.Modules.Settings.Eeprom;

namespace DroneStudio.Modules.Settings
{
    public interface ISettingsModel
    {
        void SetFloat(EepromFieldAttribute field, float value);
        float GetFloat(EepromFieldAttribute field);

        void SetShort(EepromFieldAttribute field, short value);
        short GetShort(EepromFieldAttribute field);

        IEnumerable<EepromFieldAttribute> EepromFields { get; }

        event EventHandler Modyfied;
    }
}

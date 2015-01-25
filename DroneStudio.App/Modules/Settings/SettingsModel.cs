using System;
using System.Reactive.Linq;
using System.Collections.Generic;
using DroneStudio.Library;
using DroneStudio.ApplicationLogic;
using DroneStudio.ApplicationLogic.Messages;
using DroneStudio.Modules.Settings.Eeprom;

namespace DroneStudio.Modules.Settings
{
    public class SettingsModel : ISettingsModel
    {
        public SettingsModel(IMessageLink messageLink)
        {
            this.eeprom = new Eeprom<MulticopterEeprom>();

            messageLink.IncomingMessages
                .OfType<FloatValueMessage>()
                .Subscribe(OnFloatValueMessage);

            this.eepromFields = typeof(MulticopterEeprom).GetFieldsAttributes<EepromFieldAttribute>();
        }

        public event EventHandler Modyfied;

        public IEnumerable<EepromFieldAttribute> EepromFields
        {
            get { return this.eepromFields; }
        }

        public void SetFloat(EepromFieldAttribute field, float value)
        {
            this.eeprom.WriteFloat(field.FieldOffset, value);
        }

        public float GetFloat(EepromFieldAttribute field)
        {
            return this.eeprom.ReadFloat(field.FieldOffset);
        }

        public void SetShort(EepromFieldAttribute field, short value)
        {
            this.eeprom.WriteShort(field.FieldOffset, value);
        }

        public short GetShort(EepromFieldAttribute field)
        {
            return this.eeprom.ReadShort(field.FieldOffset);
        }

        private void OnFloatValueMessage(FloatValueMessage floatValueMessage)
        {
            this.eeprom.WriteFloat(floatValueMessage.Offset, floatValueMessage.Value);
            this.RaiseModyfiedEvent();
        }

        private void RaiseModyfiedEvent()
        {
            if (this.Modyfied != null)
            {
                this.Modyfied(this, EventArgs.Empty);
            }
        }

        private readonly Eeprom<MulticopterEeprom> eeprom;
        private readonly IEnumerable<EepromFieldAttribute> eepromFields;
    }
}

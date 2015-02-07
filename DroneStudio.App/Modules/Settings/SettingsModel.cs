using System;
using System.Linq;
using System.Reactive.Linq;
using System.Collections.Generic;
using DroneStudio.Library.Extensions;
using DroneStudio.ApplicationLogic;
using DroneStudio.ApplicationLogic.Messages;
using DroneStudio.Modules.Settings.Eeprom;

namespace DroneStudio.Modules.Settings
{
    public class SettingsModel : ISettingsModel
    {
        public SettingsModel(IMessageLink messageLink)
        {
            this.messageLink = messageLink;
            this.eeprom = new Eeprom<MulticopterEeprom>();

            messageLink.IncomingMessages
                .OfType<FloatValueMessage>()
                .Subscribe(OnFloatValueMessage);

            messageLink.IncomingMessages
                .OfType<ShortValueMessage>()
                .Subscribe(OnShortValueMessage);

            this.eepromFields = typeof(MulticopterEeprom)
                .GetFieldsAttributes<EepromFieldAttribute>()
                .Select(f => new EepromField(f))
                .ToList();
        }

        public event EventHandler EepromModyfied;

        public IEnumerable<EepromField> EepromFields
        {
            get { return this.eepromFields; }
        }

        public void SetFloat(EepromField field, float value)
        {
            this.eeprom.WriteFloat(field.FieldOffset, value);
            field.Modyfied = true;
        }

        public float GetFloat(EepromField field)
        {
            return this.eeprom.ReadFloat(field.FieldOffset);
        }

        public void SetShort(EepromField field, short value)
        {
            this.eeprom.WriteShort(field.FieldOffset, value);
            field.Modyfied = true;
        }

        public short GetShort(EepromField field)
        {
            return this.eeprom.ReadShort(field.FieldOffset);
        }

        private void OnFloatValueMessage(FloatValueMessage floatValueMessage)
        {
            this.eeprom.WriteFloat(floatValueMessage.Offset, floatValueMessage.Value);
            this.RaiseModyfiedEvent();
        }

        private void OnShortValueMessage(ShortValueMessage shortValueMessage)
        {
            this.eeprom.WriteShort(shortValueMessage.Offset, shortValueMessage.Value);
            this.RaiseModyfiedEvent();
        }

        private void RaiseModyfiedEvent()
        {
            if (this.EepromModyfied != null)
            {
                this.EepromModyfied(this, EventArgs.Empty);
            }
        }

        private readonly Eeprom<MulticopterEeprom> eeprom;
        private readonly IEnumerable<EepromField> eepromFields;
        private readonly IMessageLink messageLink;
    }
}

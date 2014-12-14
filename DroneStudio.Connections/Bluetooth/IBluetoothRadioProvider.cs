using InTheHand.Net.Bluetooth;

namespace DroneStudio.Connections.Bluetooth
{
    public interface IBluetoothRadioProvider
    {
        BluetoothRadio BluetoothRadio { get; }
    }
}

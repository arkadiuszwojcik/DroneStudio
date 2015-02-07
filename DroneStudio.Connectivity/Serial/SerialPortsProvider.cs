namespace DroneStudio.Connectivity.Serial
{
    public class SerialPortsProvider
    {
        public string[] GetPortNames()
        {
            return System.IO.Ports.SerialPort.GetPortNames();
        }
    }
}

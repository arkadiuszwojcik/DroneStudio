using System.Windows.Controls;

namespace DroneStudio.Modules.PidTuner
{
    public interface IPidTunerViewFactory
    {
        PidTunerView Create();
    }
}

using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using OxyPlot;
using DroneStudio.ApplicationLogic;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using DroneStudio.ApplicationLogic.Messages;

namespace DroneStudio.Modules.PidTuner
{
    public class PidTunerViewModel : ViewModelBase
    {
        public PidTunerViewModel(IMessageLink messageLink, IScheduler dispatcherScheduler)
        {
            this.Points = new ObservableCollection<DataPoint>();

            messageLink.IncomingMessages
                .ObserveOn(dispatcherScheduler)
                .OfType<PidMeasureMessage>()
                .Subscribe(OnNewMessage);
        }

        public ObservableCollection<DataPoint> Points { get; private set; }

        private void OnNewMessage(PidMeasureMessage message)
        {
            i += 10;
            this.Points.Add(new DataPoint(i, message.Value));
        }

        int i = 0;
    }
}

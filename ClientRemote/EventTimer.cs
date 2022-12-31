using MyViewer.ClientHost;
using MyViewer.Core;
using System;
using System.Timers;

namespace MyViewer.ClientRemote
{
    public class EventTimer
    {
        private Timer timer; 

        private ISender sender;
        
        public EventTimer(ISender sender)
        {
            this.sender = sender;
        }
        public void Start()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Elapsed += OnTimedEvent;
            timer.Enabled = true;
        }

        public void Stop()
        {
            timer.Stop();
        }

        private  void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            sender.Send(new ImageData());
        }

    }
}

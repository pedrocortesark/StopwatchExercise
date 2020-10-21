using System;
using System.Timers;
using System.Windows;

namespace TimerWPF.Infraestructure
{
    public class TimerController : ITimerController
    {

        public Action<DateTime> UpdateDataAction { get; set; }

        public DateTime ElapsedTime { get; set; }

        public Timer Timer { get; set; }

        public TimerController()
        {

        }

        public void Reset()
        {
            this.ElapsedTime = new DateTime();
            if (this.UpdateDataAction != null)
            {
                this.UpdateDataAction(this.ElapsedTime);
            }
        }

        public void Start()
        {
            Timer = new Timer(1000);
            Timer.Elapsed += Timer_Elapsed;
            Timer.AutoReset = true;
            Timer.Enabled = true;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                this.ElapsedTime = this.ElapsedTime.AddSeconds(1);
                if (this.UpdateDataAction != null)
                {
                    this.UpdateDataAction(this.ElapsedTime);
                }
            });
        }

        public void Stop()
        {
            Timer.Stop();
        }
    }
}

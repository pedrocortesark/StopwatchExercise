using System;
using System.Windows.Input;
using TimerWPF.Infraestructure;
using TimerWPF.Infraestructure.Comments;

namespace TimerWPF.ViewModels
{
    public class StopwatchViewModel : GenericViewModel
    {

        public ICommand StartCommand { get; set; }
        public ICommand StopCommand { get; set; }
        public ICommand ResetCommand { get; set; }


        public string _content;
        public string Content
        {
            get
            {
                return _content;
            }
            set
            {
                _content = value;
                OnPropertyChanged("Content");
            }
        }

        public ITimerController TimerController { get; set; }
        

        public StopwatchViewModel(ITimerController timerController)
        {
            this.TimerController = timerController;
            this.TimerController.UpdateDataAction = this.PrintTime;

            TimerController.Reset();

            StartCommand = new RelayCommand(new Action(Start));
            StopCommand = new RelayCommand(new Action(Stop));
            ResetCommand = new RelayCommand(new Action(Reset));
        }

        private void PrintTime(DateTime dt)
        {
            this.Content = $"{dt.Hour:00}:{dt.Minute:00}:{dt.Second:00}";
        }

        public void Start()
        {
            this.TimerController.Start();
        }

        public void Stop()
        {
            this.TimerController.Stop();
        }

        public void Reset()
        {
            this.TimerController.Reset();
        }


    }
}

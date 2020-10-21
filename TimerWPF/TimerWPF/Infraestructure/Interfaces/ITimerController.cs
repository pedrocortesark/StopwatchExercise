using System;
using System.Collections.Generic;
using System.Text;

namespace TimerWPF.Infraestructure
{
    //For interface segregation and dependency injection
    public interface ITimerController
    {
        Action<DateTime> UpdateDataAction { get; set; }
        void Start();
        void Reset();
        void Stop();
    }
}

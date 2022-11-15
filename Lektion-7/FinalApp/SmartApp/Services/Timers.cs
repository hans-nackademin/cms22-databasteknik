﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace SmartApp.Services
{
    internal abstract class Timers
    {
        public Timers()
        {
            InitiallizeTimers();
        }

        protected virtual void InitiallizeTimers()
        {
            DispatcherTimer ClockTimer = new DispatcherTimer();
            ClockTimer.Interval = TimeSpan.FromSeconds(1);
            ClockTimer.Tick += second_timer_tick;
            ClockTimer.Start();

            DispatcherTimer TemperatureTimer = new DispatcherTimer();
            TemperatureTimer.Interval = TimeSpan.FromHours(1);
            TemperatureTimer.Tick += hour_timer_tick;
            TemperatureTimer.Start();
        }

        protected virtual void second_timer_tick(object? sender, EventArgs e)
        {

        }

        protected virtual void hour_timer_tick(object? sender, EventArgs e)
        {

        }
    }
}

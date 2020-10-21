﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TimerWPF.Infraestructure;
using TimerWPF.ViewModels;

namespace TimerWPF.Views
{
    /// <summary>
    /// Interaction logic for StopwatchView.xaml
    /// </summary>
    public partial class StopwatchView : UserControl
    {
        public StopwatchView()
        {
            InitializeComponent();
            this.DataContext = new StopwatchViewModel(new TimerController());
        }
    }
}

﻿using EggDrop_Kiosk.Core.Complete.ViewModel;
using EggDrop_Kiosk.Core.Table.ViewModel;
using EggDrop_Kiosk.Core.TcpClient.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using UIStateManagerLibrary;

namespace EggDrop_Kiosk.Control.Card
{
    /// <summary>
    /// UserControl1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CardControl : CustomControlModel
    {
        DispatcherTimer timer = new DispatcherTimer();

        public CardControl()
        {
            InitializeComponent();
            webcam.CameraIndex = 0;
            Loaded += CardControl_Loaded;
        }

        private void CardControl_Loaded(object sender, RoutedEventArgs e)
        {
            tbTotalPrice.DataContext = App.orderViewModel;
        }

        private void webcam_QrDecoded(object sender, string e)
        {
            tbRecog.Text = e;
        }

        private void tbRecog_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbRecog.Text != "" && (tbRecog.Text == "정재덕" ||
                tbRecog.Text == "신희송" ||
                tbRecog.Text == "크리스"))
            {
                App.uIStateManager.SwitchCustomControl(CustomControlType.PAYCOMPLETE);

                App.completeViewModel.InsertIdByName(tbRecog.Text);
          
                App.SendOrderInfo();
                tbRecog.Text = "";

                if (App.tableViewModel.SelectedTable != null)
                {
                    App.tableViewModel.SelectedTable.PaidTime = DateTime.Now;
                    App.tableViewModel.InitInstance();
                }
                timer.Interval = TimeSpan.FromSeconds(5);
                timer.Tick += Timer_Tick;
                timer.Start();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            App.orderViewModel.ClearOrderedProductModels();
            App.uIStateManager.SwitchCustomControl(CustomControlType.HOME);
        }
    }
}

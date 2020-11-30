﻿using EggDrop_Kiosk.Core.Complete.ViewModel;

using EggDrop_Kiosk.Core.Table.ViewModel;
using EggDrop_Kiosk.Core.TcpClient.Model;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using UIStateManagerLibrary;

namespace EggDrop_Kiosk.Control.Cash
{
    /// <summary>
    /// UserControl1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CashControl : CustomControlModel
    {
        DispatcherTimer timer = new DispatcherTimer();
        public CashControl()
        {
            InitializeComponent();
            Loaded += CashControl_Loaded;
            barcodeValue.Loaded += BarcodeValue_Loaded;
            barcodeValue.TextChanged += BarcodeValue_TextChanged;
        }

        private void BarcodeValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (barcodeValue.Text != "" && (barcodeValue.Text == "2112345678900" ||
                barcodeValue.Text == "02345673" ||
                barcodeValue.Text == "9790260532113"))
            {
                App.uIStateManager.SwitchCustomControl(CustomControlType.PAYCOMPLETE);

                App.completeViewModel.InsertNameById(barcodeValue.Text);

                if (App.isTable)
                {
                    if (App.tableViewModel.SelectedTable != null)
                    {
                        App.completeViewModel.InsertData(App.isCard, App.tableViewModel.SelectedTable.Number, App.orderViewModel.OrderedProductModels);
                    }
                }
                else
                {
                    App.completeViewModel.InsertData(App.isCard, 0, App.orderViewModel.OrderedProductModels);
                }

                barcodeValue.Text = "";

                barcodeValue.SelectAll();
                Keyboard.Focus(barcodeValue);

                if (App.tableViewModel.SelectedTable != null)
                {
                    App.tableViewModel.SelectedTable.PaidTime = DateTime.Now;
                    App.tableViewModel.InitInstance();
                }

                SendOrderInfo();
                completeViewModel.InsertData();
                timer.Interval = TimeSpan.FromSeconds(5);
                timer.Tick += Timer_Tick; ;
                timer.Start();
            }

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            App.orderViewModel.ClearOrderedProductModels();
            App.uIStateManager.SwitchCustomControl(CustomControlType.HOME);
        }

        private void BarcodeValue_Loaded(object sender, RoutedEventArgs e)
        {
            Keyboard.Focus(barcodeValue);
        }

        private void CashControl_Loaded(object sender, RoutedEventArgs e)
        {
            tbTotalPrice.DataContext = App.orderViewModel;
        }

        private void SendOrderInfo()
        {
            RequestModel requestModel = new RequestModel();
            requestModel.MSGType = 0;
            requestModel.ShopName = "";
            //for (int i = 0; i )
            requestModel.Menus = null;
            requestModel.Content = "";
            requestModel.OrderNumber = "";

            App.tcpClientViewModel.StartConnection();
            App.tcpClientViewModel.Send(requestModel);
        }
    }
}
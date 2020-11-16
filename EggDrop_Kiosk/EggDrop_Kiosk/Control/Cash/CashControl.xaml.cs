using EggDrop_Kiosk.Core.Complete.ViewModel;
using EggDrop_Kiosk.Core.Table.ViewModel;
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
        private TableViewModel tableViewModel = TableViewModel.Instance;
        private CompleteViewModel completeViewModel = new CompleteViewModel();
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
            if (Equals(barcodeValue.Text, "123"))
            {
                if (tableViewModel.SelectedTable != null)
                {
                    tableViewModel.SelectedTable.PaidTime = DateTime.Now;
                    tableViewModel.InitInstance();
                }

                App.uIStateManager.SwitchCustomControl(CustomControlType.PAYCOMPLETE);
                barcodeValue.Text = "";
                barcodeValue.SelectAll();
                Keyboard.Focus(barcodeValue);

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
    }
}
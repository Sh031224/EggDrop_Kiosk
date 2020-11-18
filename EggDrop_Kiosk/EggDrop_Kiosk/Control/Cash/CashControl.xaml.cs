using EggDrop_Kiosk.Core.Complete.ViewModel;
using EggDrop_Kiosk.Core.TcpClient.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using UIStateManagerLibrary;
using ZXing;

namespace EggDrop_Kiosk.Control.Cash
{
    /// <summary>
    /// UserControl1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CashControl : CustomControlModel
    {
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
            if (Equals(barcodeValue.Text, "02345673"))
            {
                App.uIStateManager.SwitchCustomControl(CustomControlType.PAYCOMPLETE);
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
            App.uIStateManager.SwitchCustomControl(CustomControlType.HOME);
        }

        private void BarcodeValue_Loaded(object sender, RoutedEventArgs e)
        {
            Keyboard.Focus((TextBox)sender);
        }

        private void CashControl_Loaded(object sender, RoutedEventArgs e)
        {
            tbTotalPrice.DataContext = App.orderViewModel.OrderedTotalPrice;
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

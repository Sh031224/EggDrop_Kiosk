using EggDrop_Kiosk.Core.Complete.ViewModel;
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

namespace EggDrop_Kiosk.Control.Card
{
    /// <summary>
    /// UserControl1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CardControl : CustomControlModel
    {
        private CompleteViewModel completeViewModel = new CompleteViewModel();
        DispatcherTimer timer = new DispatcherTimer();

        public CardControl()
        {
            InitializeComponent();
            webcam.CameraIndex = 0;
            Loaded += CardControl_Loaded;
        }

        private void CardControl_Loaded(object sender, RoutedEventArgs e)
        {
            tbTotalPrice.DataContext = App.orderViewModel.OrderedTotalPrice;
        }

        private void webcam_QrDecoded(object sender, string e)
        {
            tbRecog.Text = e;
        }

        private void tbRecog_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Equals(tbRecog.Text, "정재덕"))
            {
                App.uIStateManager.SwitchCustomControl(CustomControlType.PAYCOMPLETE);
                completeViewModel.InsertData();
                timer.Interval = TimeSpan.FromSeconds(5);
                timer.Tick += Timer_Tick;
                timer.Start();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            App.uIStateManager.SwitchCustomControl(CustomControlType.HOME);
        }
    }
}

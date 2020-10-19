using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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

namespace EggDrop_Kiosk
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
          // 데이터 로드
            App.orderData.orderViewModel.LoadData();
            
            CtrlHome.BtnAdmin.Click += BtnAdmin_Click;
            CtrlHome.BtnOrder.Click += BtnOrder_Click;
            CtrlPay.BtnCard.Click += BtnCard_Click;
            CtrlPay.BtnCash.Click += BtnCash_Click;
        }

        private void Clock_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 1)
            };
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Clock.Text = DateTime.Now.ToString();
        }

        private void BtnCard_Click(object sender, RoutedEventArgs e)
        {
            CtrlPay.Visibility = Visibility.Collapsed;
            CtrlCard.Visibility = Visibility.Visible;
        }
        private void BtnCash_Click(object sender, RoutedEventArgs e)
        {
            CtrlPay.Visibility = Visibility.Collapsed;
            CtrlCash.Visibility = Visibility.Visible;
        }

        private void BtnOrder_Click(object sender, RoutedEventArgs e)
        {
            // 시작 페이지에서 주문 페이지로 이동
            CtrlHome.Visibility = Visibility.Collapsed;
            CtrlOrder.Visibility = Visibility.Visible;
        }
       
        private void BtnAdmin_Click(object sender, RoutedEventArgs e)
        {
            CtrlHome.Visibility = Visibility.Collapsed;
            CtrlAdmin.Visibility = Visibility.Visible;
        }
    }
}

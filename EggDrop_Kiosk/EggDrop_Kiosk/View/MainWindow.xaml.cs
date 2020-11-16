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
using UIStateManagerLibrary;

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
            SetCustomControls();
            SetStartCustomControl();

          // 데이터 로드
            App.orderViewModel.LoadData();
            App.adminViewModel.GetOrderInfo();


            CtrlHome.BtnAdmin.Click += BtnAdmin_Click;
            CtrlHome.BtnOrder.Click += BtnOrder_Click;
            CtrlPay.BtnCard.Click += BtnCard_Click;
            CtrlPay.BtnCash.Click += BtnCash_Click;
            CtrlPlace.BtnPrevious.Click += BtnPlacePrevious_Click;
            CtrlPlace.BtnPlacePay.Click += BtnPlacePay_Click;
            CtrlPlace.BtnPlaceTable.Click += BtnPlaceTable_Click;
            CtrlOrder.BtnOrderNext.Click += BtnOrderNext_Click;
            CtrlPay.BtnPrevious.Click += BtnPayPrevious_Click;
            CtrlOrder.BtnPrevious.Click += BtnOrderPrevious_Click;
            CtrlCard.BtnPrevious.Click += BtnCardPrevious_Click;
            CtrlCash.BtnPrevious.Click += BtnCashPrevious_Click;
        }

        private void SetCustomControls()
        {
            App.uIStateManager.SetCustomCtrl(CtrlLogin, CustomControlType.LOGIN);
            App.uIStateManager.SetCustomCtrl(CtrlHome, CustomControlType.HOME);
            App.uIStateManager.SetCustomCtrl(CtrlOrder, CustomControlType.ORDER);
            App.uIStateManager.SetCustomCtrl(CtrlTable, CustomControlType.TABLE);
            App.uIStateManager.SetCustomCtrl(CtrlPlace, CustomControlType.PLACE);
            App.uIStateManager.SetCustomCtrl(CtrlPay, CustomControlType.PAY);
            App.uIStateManager.SetCustomCtrl(CtrlCard, CustomControlType.PAYCARD);
            App.uIStateManager.SetCustomCtrl(CtrlCash, CustomControlType.PAYCASH);
            App.uIStateManager.SetCustomCtrl(CtrlComplete, CustomControlType.PAYCOMPLETE);
            App.uIStateManager.SetCustomCtrl(CtrlAdmin, CustomControlType.ADMIN);
            App.uIStateManager.SetCustomCtrl(CtrlComplete, CustomControlType.PAYCOMPLETE);
        }

        private void SetStartCustomControl()
        {
            App.uIStateManager.PushCustomCtrl(CtrlLogin);
        }

        private void BtnCashPrevious_Click(object sender, RoutedEventArgs e)
        {
            App.uIStateManager.SwitchCustomControl(CustomControlType.PAY);
        }

        private void BtnCardPrevious_Click(object sender, RoutedEventArgs e)
        {
            App.uIStateManager.SwitchCustomControl(CustomControlType.PAY);
        }

        private void BtnOrderPrevious_Click(object sender, RoutedEventArgs e)
        {
            App.uIStateManager.SwitchCustomControl(CustomControlType.HOME);
        }

        private void BtnPlacePrevious_Click(object sender, RoutedEventArgs e)
        {
            App.uIStateManager.SwitchCustomControl(CustomControlType.ORDER);
        }
        
        private void BtnPlacePay_Click(object sender, RoutedEventArgs e)
        {
            App.uIStateManager.SwitchCustomControl(CustomControlType.PAY);
        }
        
        private void BtnPlaceTable_Click(object sender, RoutedEventArgs e)
        {
            App.uIStateManager.SwitchCustomControl(CustomControlType.TABLE);
        }

        private void BtnPayPrevious_Click(object sender, RoutedEventArgs e)
        {
            App.uIStateManager.SwitchCustomControl(CustomControlType.PLACE);
        }

        private void BtnOrderNext_Click(object sender, RoutedEventArgs e)
        {
            if (App.orderViewModel.OrderedProductModels.Count() == 0)
            {
                MessageBox.Show("상품이 없습니다.");
                return;
            }

            App.uIStateManager.SwitchCustomControl(CustomControlType.PLACE);
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
            App.uIStateManager.SwitchCustomControl(CustomControlType.PAYCARD);
        }
        private void BtnCash_Click(object sender, RoutedEventArgs e)
        {
            App.uIStateManager.SwitchCustomControl(CustomControlType.PAYCASH);
        }

        private void BtnOrder_Click(object sender, RoutedEventArgs e)
        {
            App.uIStateManager.SwitchCustomControl(CustomControlType.ORDER);
        }
       
        private void BtnAdmin_Click(object sender, RoutedEventArgs e)
        {
            App.uIStateManager.SwitchCustomControl(CustomControlType.ADMIN);
        }

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            if (App.orderViewModel.OrderedProductModels.Count > 0)
            {
                if (MessageBox.Show("주문 중인 내용이 모두 사라집니다.", "홈 이동.", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    App.orderViewModel.ClearOrderedProductModels();
                    App.uIStateManager.SwitchCustomControl(CustomControlType.HOME);
                }
            } else
            {
                App.uIStateManager.SwitchCustomControl(CustomControlType.HOME);
            }
            
        }

    }
}

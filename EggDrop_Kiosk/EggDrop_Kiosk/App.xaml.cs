using EggDrop_Kiosk.Core.Admin.ViewModel;
using EggDrop_Kiosk.Core.Complete.ViewModel;
using EggDrop_Kiosk.Common;
using EggDrop_Kiosk.Core.Order;
using EggDrop_Kiosk.Core.Order.ViewModel;
using EggDrop_Kiosk.Core.Table.ViewModel;
using EggDrop_Kiosk.Core.TcpClient.ViewModel;
using EggDrop_Kiost.Core.Login.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using UIStateManagerLibrary;
using EggDrop_Kiosk.Core.TcpClient.Model;

namespace EggDrop_Kiosk
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
        public static UIStateManager uIStateManager = new UIStateManager();
        public static OrderViewModel orderViewModel = new OrderViewModel();
        public static CompleteViewModel completeViewModel = new CompleteViewModel();
        public static TableViewModel tableViewModel = TableViewModel.Instance;
        public static LoginViewModel loginViewModel = new LoginViewModel();
        public static AdminViewModel adminViewModel = new AdminViewModel();

        public static int isCard;
        public static bool isTable;

        public static TcpClientViewModel tcpClientViewModel = new TcpClientViewModel();

        public DateTime StartTime = DateTime.Now;

        // WPF 전역 예외처리, 어플리케이션 강제 종료 방지
        //private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        //{
        //    MessageBox.Show("An unhandled exception just occured: " + e.Exception, "예외 발생", MessageBoxButton.OK, MessageBoxImage.Error);
        //    e.Handled = true;
        //}

        public static SettingPreference settingPreference = new SettingPreference();

        public static void SendOrderInfo()
        {
            completeViewModel.InsertData(isCard, isTable ? tableViewModel.SelectedTable.Number : 0, orderViewModel.OrderedProductModels);

            RequestModel requestModel = new RequestModel();
            requestModel.MSGType = EMsgType.ORDER_INFO;
            requestModel.ShopName = "승호의 맛나는 EggDrop";

            List<RequestMenuModel> menus = new List<RequestMenuModel>();

            for (int i = 0; i < orderViewModel.OrderedProductModels.Count; i++)
            {
                menus.Add(new RequestMenuModel()
                {
                    Count = orderViewModel.OrderedProductModels[i].Count,
                    Name = orderViewModel.OrderedProductModels[i].Name,
                    Price = orderViewModel.OrderedProductModels[i].SalePrice
                });
            }

            requestModel.OrderNumber = (completeViewModel.OrderIdx % 100).ToString().PadLeft(2, '0');
            requestModel.Menus = menus;
            requestModel.Content = "";

            tcpClientViewModel.Send(requestModel);
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
           adminViewModel.AddUsageTime();
        }
    }
}

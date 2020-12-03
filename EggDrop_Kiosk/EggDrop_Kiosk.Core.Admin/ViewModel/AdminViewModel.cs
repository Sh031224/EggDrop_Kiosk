using EggDrop_Kiosk.Core.Admin.Model;
using EggDrop_Kiosk.Core.Admin.Service;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace EggDrop_Kiosk.Core.Admin.ViewModel
{
    public class AdminViewModel: BindableBase
    {
        private OrderInfoService orderInfoService = new OrderInfoService();
        private UsageTimeService usageTimeService = new UsageTimeService();

        private ObservableCollection<OrderInfoModel> _orderInfos = new ObservableCollection<OrderInfoModel>();
        public ObservableCollection<OrderInfoModel> OrderInfoModel
        {
            get => _orderInfos;
            set => SetProperty(ref _orderInfos, value);
        }

        public TimeSpan UsageTime { get; set; }

        public void GetOrderInfo()
        {
            OrderInfoModel = orderInfoService.GetOrderInfoModels();
        }

        public void GetUsageTime()
        {
            UsageTime = usageTimeService.GetUsageTime();
            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 1)
            };
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UsageTime = UsageTime.Add(new TimeSpan(0, 0, 1));
        }

        public void AddUsageTime()
        {
            usageTimeService.AddUsageTime(UsageTime);
        }
    }
}

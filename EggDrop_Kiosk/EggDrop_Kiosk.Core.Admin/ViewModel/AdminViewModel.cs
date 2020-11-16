using EggDrop_Kiosk.Core.Admin.Model;
using EggDrop_Kiosk.Core.Admin.Service;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggDrop_Kiosk.Core.Admin.ViewModel
{
    public class AdminViewModel: BindableBase
    {
        private OrderInfoService orderInfoService = new OrderInfoService();

        private ObservableCollection<OrderInfoModel> _orderInfos = new ObservableCollection<OrderInfoModel>();
        public ObservableCollection<OrderInfoModel> OrderInfoModel
        {
            get => _orderInfos;
            set => SetProperty(ref _orderInfos, value);
        }

        public void GetOrderInfo()
        {
            OrderInfoModel = orderInfoService.GetOrderInfoModels();
        }
    }
}

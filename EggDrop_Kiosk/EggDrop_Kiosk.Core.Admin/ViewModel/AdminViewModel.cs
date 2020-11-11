using EggDrop_Kiosk.Core.Admin.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggDrop_Kiosk.Core.Admin.ViewModel
{
    public class AdminViewModel
    {
        private OrderInfoService orderInfoService = new OrderInfoService();

        public void GetOrderInfo()
        {
            orderInfoService.GetOrderInfoModels();
        }
    }
}

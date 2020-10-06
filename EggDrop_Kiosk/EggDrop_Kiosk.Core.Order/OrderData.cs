using EggDrop_Kiosk.Core.Order.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggDrop_Kiosk.Core.Order
{
    public class OrderData
    {
        public OrderViewModel orderViewModel = new OrderViewModel();

        public void LoadDataAsync()
        {
            orderViewModel.LoadData();
        }
    }
}

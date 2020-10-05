using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggDrop_Kiosk.Core.Order.Model
{
    public class ProductModel
    {
        private string name { get; set; }
        private string imagePath { get; set; }
        private ECategory category { get; set; }
        private int price { get; set; }
        private int salePercent { get; set; }
        private int count { get; set; }
    }
}

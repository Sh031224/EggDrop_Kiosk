using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggDrop_Kiosk.Core.TcpClient.Model
{
    public class RequestMenuModel
    {
        public String Name { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
    }
}

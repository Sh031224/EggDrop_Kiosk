using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggDrop_Kiosk.Core.TcpClient.Model
{
    public class RequestModel
    {
        public EMsgType MSGType { get; set; }
        public String Id { get; set; }
        public String Content { get; set; }
        public String ShopName { get; set; }
        public String OrderNumber { get; set; }
        public List<RequestMenuModel> Menus { get; set; }
    }
}

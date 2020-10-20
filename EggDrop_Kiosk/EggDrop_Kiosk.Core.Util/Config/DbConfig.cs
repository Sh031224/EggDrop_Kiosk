using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggDrop_Kiosk.Config
{
    public class DbConfig
    {
        private const String CONNECTIONSTRING = "SERVER = 10.80.163.204; DATABASE=kiosk;UID=root;PASSWORD=1234;";

        public String GetConnectionString()
        {
            return CONNECTIONSTRING;
        }
    }
}

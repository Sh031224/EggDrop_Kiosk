using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggDrop_Kiosk.Core.Util.Config
{
    public class TcpClientConfig
    {
        private const String SERVERURL = "10.80.162.152";
        private const int PORT = 80;
        private const String GRADE = "2118";

        public String GetServerUrl()
        {
            return SERVERURL;
        }

        public int GetPort()
        {
            return PORT;
        }

        public String GetGrade()
        {
            return GRADE;
        }
    }
}

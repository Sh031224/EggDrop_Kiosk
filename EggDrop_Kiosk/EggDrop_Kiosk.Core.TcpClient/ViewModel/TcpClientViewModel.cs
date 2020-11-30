using EggDrop_Kiosk.Core.TcpClient.Model;
using EggDrop_Kiosk.Core.TcpClient.Service;
using EggDrop_Kiosk.Core.Util.Config;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggDrop_Kiosk.Core.TcpClient.ViewModel
{
    public class TcpClientViewModel
    {
        private TcpClientService tcpClientService = new TcpClientService();
        private TcpClientConfig tcpClientConfig = new TcpClientConfig();

        public void StartConnection()
        {
            tcpClientService.start();
        }

        public void CloseConnection()
        {
            tcpClientService.close();
        }

        public void Send(RequestModel requestModel)
        {
            requestModel.Id = tcpClientConfig.GetGrade();
            tcpClientService.SendMessage(JsonConvert.SerializeObject(requestModel));
        }
    }
}

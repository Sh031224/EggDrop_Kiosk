using EggDrop_Kiosk.Core.Complete.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggDrop_Kiosk.Core.Complete.ViewModel
{
    public class CompleteViewModel
    {
        private ReceiptService receiptService = new ReceiptService();

        public void InsertData()
        {
            receiptService.PostReceipt();
        }
    }
}

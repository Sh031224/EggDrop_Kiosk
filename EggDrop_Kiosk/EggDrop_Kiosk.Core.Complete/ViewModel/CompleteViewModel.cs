using EggDrop_Kiosk.Core.Complete.Service;
using EggDrop_Kiosk.Core.Order.Model;
using EggDrop_Kiosk.Core.TcpClient.Model;
using Google.Protobuf.WellKnownTypes;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggDrop_Kiosk.Core.Complete.ViewModel
{
    public class CompleteViewModel: BindableBase
    {
        private ReceiptService receiptService = new ReceiptService();

        private int _orderIdx = 0;
        public int OrderIdx
        {
            get => _orderIdx;
            set => SetProperty(ref _orderIdx, value);
        }

        public void InsertIdByName(string userName)
        {
            receiptService.GetUserId(userName);
        }

        public void InsertNameById(string userId)
        {
            receiptService.GetUserName(userId);
        }

        public void InsertData(int isCard, int tableNumber, ObservableCollection<ProductModel> productModels)
        {
            OrderIdx = receiptService.PostReceipt(isCard, tableNumber, productModels);
        }
    }
}

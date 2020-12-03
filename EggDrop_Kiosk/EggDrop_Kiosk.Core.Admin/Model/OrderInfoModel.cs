using EggDrop_Kiosk.Core.Order.Model;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggDrop_Kiosk.Core.Admin.Model
{
    public class OrderInfoModel: BindableBase
    {
        private int _orderIdx;
        public int OrderIdx
        {
            get => _orderIdx;
            set => SetProperty(ref _orderIdx, value);
        }

        private String _userId;
        public String UserId
        {
            get => _userId;
            set => SetProperty(ref _userId, value);
        }

        private String _userName;
        public String UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }

        private ProductModel _product;
        public ProductModel Product
        {
            get => _product;
            set => SetProperty(ref _product, value);
        }

        private Boolean _isCard;
        public Boolean IsCard
        {
            get => _isCard;
            set => SetProperty(ref _isCard, value);
        }

        private int? _tableNumber;
        public int? TableNumber
        {
            get => _tableNumber;
            set => SetProperty(ref _tableNumber, value);
        }

        private DateTime _createdAt;
        public DateTime CreatedAt
        {
            get => _createdAt;
            set => SetProperty(ref _createdAt, value);
        }
    }
}

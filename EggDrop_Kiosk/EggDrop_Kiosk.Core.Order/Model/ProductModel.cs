using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggDrop_Kiosk.Core.Order.Model
{
    public class ProductModel: BindableBase
    {
        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _imagePath;
        public string ImagePath
        {
            get => _imagePath;
            set => SetProperty(ref _imagePath, value);
        }

        private ECategory _category;
        public ECategory Category
        {
            get => _category;
            set => SetProperty(ref _category, value);
        }

        private int _price;
        public int Price
        {
            get => _price;
            set => SetProperty(ref _price, value);
        }

        private int _salePercent;
        public int SalePercent
        {
            get => _salePercent;
            set => SetProperty(ref _salePercent, value);
        }

        private int _count;
        public int Count
        {
            get => _count;
            set => SetProperty(ref _count, value);
        }
    }
}

using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggDrop_Kiosk.Core.Order.Model
{
    public class CategoryModel: BindableBase
    {
        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private ECategory _category;
        public ECategory Category
        {
            get => _category;
            set => SetProperty(ref _category, value);
        }

    }
}

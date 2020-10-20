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
        private int _idx;
        public int Idx
        {
            get => _idx;
            set => SetProperty(ref _idx, value);
        }

        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

    }
}

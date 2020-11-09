using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UIStateManagerLibrary;

namespace EggDrop_Kiosk.Control.Pay
{
    /// <summary>
    /// PayControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PayControl : CustomControlModel
    {
        public PayControl()
        {
            InitializeComponent();

            Loaded += PayControl_Loaded; ;
            tbTotalPrice.DataContext = App.orderViewModel.OrderedTotalPrice;
        }

        private void PayControl_Loaded(object sender, RoutedEventArgs e)
        {
            lvOrdered.ItemsSource = App.orderViewModel.OrderedProductModels;
        }

    }
}

using EggDrop_Kiosk.Core.Complete.ViewModel;
using EggDrop_Kiosk.Core.Table.ViewModel;
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
using System.Windows.Threading;
using UIStateManagerLibrary;

namespace EggDrop_Kiosk.Control.Complete
{
    /// <summary>
    /// CompleteControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CompleteControl : CustomControlModel
    {

        public CompleteControl()
        {
            InitializeComponent();
            Loaded += CompleteControl_Loaded;
        }

        private void CompleteControl_Loaded(object sender, RoutedEventArgs e)
        {
            tbTotalPrice.DataContext = App.orderViewModel;
            tbOrderIdx.DataContext = App.completeViewModel;
        }
    }
}

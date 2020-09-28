using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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

namespace EggDrop_Kiosk
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CtrlHome.BtnOrder.Click += BtnOrder_Click;
        }

        private void BtnOrder_Click(object sender, RoutedEventArgs e)
        {
            // 시작 페이지에서 주문 페이지로 이동
            CtrlHome.Visibility = Visibility.Collapsed;
            CtrlOrder.Visibility = Visibility.Visible;
        }
    }
}

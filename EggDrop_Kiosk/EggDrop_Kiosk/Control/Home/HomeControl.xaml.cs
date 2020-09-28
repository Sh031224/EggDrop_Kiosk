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

namespace EggDrop_Kiosk.Control.Home
{
    /// <summary>
    /// HomeControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class HomeControl : UserControl
    {
        public HomeControl()
        {
            InitializeComponent();
        }

        private void EggDropVideoEnded(object sender, RoutedEventArgs e)
        {
            this.EggDropVideo.Stop();
            this.EggDropVideo.Position = TimeSpan.FromSeconds(0);
            this.EggDropVideo.Play();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}

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

            Loaded += HomeControl_Loaded;
        }

        private void HomeControl_Loaded(object sender, RoutedEventArgs e)
        {
            // 비디오 자동 재생
            EggDropVideo.Play();
        }

        // 비디오 무한 재생
        private void EggDropVideoEnded(object sender, RoutedEventArgs e)
        {
            EggDropVideo.Stop();
            EggDropVideo.Position = TimeSpan.FromSeconds(0);
            EggDropVideo.Play();
        }
    }
}

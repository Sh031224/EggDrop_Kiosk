using EggDrop_Kiosk.Common;
using EggDrop_Kiosk.Properties;
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

namespace EggDrop_Kiosk.Control.Admin
{
    /// <summary>
    /// AdminControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AdminControl : CustomControlModel
    {
        public AdminControl()
        {
            InitializeComponent();
            Loaded += AdminControl_Loaded;
        }

        private void AdminControl_Loaded(object sender, RoutedEventArgs e)
        {
            tbClock.Text = App.adminViewModel.UsageTime.ToString();
            cbAutoLogin.DataContext = App.settingPreference;
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            App.settingPreference.AutoLogin = false;
            App.uIStateManager.SwitchCustomControl(CustomControlType.LOGIN);
        }

        private void cbAutoLogin_Click(object sender, RoutedEventArgs e)
        {
            App.settingPreference.AutoLogin = (bool)cbAutoLogin.IsChecked;
        }
    }
}

using EggDrop_Kiosk.Core.Order.Model;
using EggDrop_Kiosk.Core.TcpClient.Model;
using EggDrop_Kiosk.Properties;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

namespace EggDrop_Kiosk.Control.Login
{
    /// <summary>
    /// LoginControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LoginControl : CustomControlModel
    {
        public LoginControl()
        {
            InitializeComponent();
            Loaded += LoginControl_Loaded;
        }

        private void LoginControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (Settings.Default.autoLogin)
            {
                LoginSuccess();
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (tbUserId.Text != "" && tbUserPw.Password != "")
            {
                Boolean success = App.loginViewModel.TryLogin(tbUserId.Text, tbUserPw.Password);

                Settings.Default.autoLogin = (bool)cbAutoLogin.IsChecked;
                Settings.Default.Save();

                if (success)
                {
                    LoginSuccess();
                } else
                {
                    MessageBox.Show("로그인에 실패하였습니다.");
                }
            }
        }

        private void LoginSuccess()
        {
            App.uIStateManager.SwitchCustomControl(CustomControlType.HOME);
        }
    }
}

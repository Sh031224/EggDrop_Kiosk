using EggDrop_Kiosk.Properties;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggDrop_Kiosk.Common
{
    public class SettingPreference: BindableBase
    {
        private bool _autoLogin = Settings.Default.autoLogin;
        public bool AutoLogin
        {
            get => _autoLogin;
            set
            {
                SetProperty(ref _autoLogin, value);
                Settings.Default.autoLogin = _autoLogin;
                Settings.Default.Save();
            }
        }
    }
}

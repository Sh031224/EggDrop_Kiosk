using EggDrop_Kiost.Core.Login.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggDrop_Kiost.Core.Login.ViewModel
{
    public class LoginViewModel
    {
        private LoginService loginService = new LoginService();

        public Boolean TryLogin(String userId, String userPw)
        {
            return loginService.TryLogin(userId, userPw);
        }
    }
}

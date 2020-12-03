using EggDrop_Kiosk.Core.Util;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggDrop_Kiost.Core.Login.Service
{
    class LoginService
    {
        public Boolean TryLogin(String userId, String userPw)
        {
            DbConnection dbConnection = new DbConnection();

            dbConnection.Connect();
            dbConnection.SetCommand("SELECT * FROM user");

            MySqlDataReader reader = dbConnection.ExecuteQuery();

            Boolean flag = false;
            while (reader.Read())
            {
                if (userId == reader["id"].ToString() && userPw == reader["pw"].ToString())
                {
                    flag = true;
                    break;
                }
            }

            dbConnection.CloseConnection();

            return flag;
        }
    }
}

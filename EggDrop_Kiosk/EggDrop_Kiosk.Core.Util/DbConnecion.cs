using EggDrop_Kiosk.Config;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggDrop_Kiosk.Core.Util
{
    public class DbConnecion
    {
        private MySqlConnection connection = null;
        private MySqlCommand command = null;

        public void Connect()
        {
            DbConfig dbConfig = new DbConfig();

            string strDBConnection = dbConfig.GetConnectionString();
            connection = new MySqlConnection(strDBConnection);
            connection.Open();
        }

        public void CloseConnection()
        {
            connection.Close();
        }

        public void SetCommand(string strCommand)
        {
            command = new MySqlCommand(strCommand, connection);
        }

        public int Execute()
        {
            return command.ExecuteNonQuery();
        }

        public MySqlDataReader ExecuteQuery()
        {
            return command.ExecuteReader();
        }
    }
}

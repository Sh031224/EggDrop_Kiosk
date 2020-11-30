using EggDrop_Kiosk.Core.Util.Config;
using MySql.Data.MySqlClient;
using EggDrop_Kiosk.Config;

namespace EggDrop_Kiosk.Core.Util
{
    public class DbConnection
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

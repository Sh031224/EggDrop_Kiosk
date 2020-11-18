using EggDrop_Kiosk.Core.Util;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggDrop_Kiosk.Core.Admin.Service
{
    public class UsageTimeService
    {
        public TimeSpan GetUsageTime()
        {
            DbConnection dbConnection = new DbConnection();

            dbConnection.Connect();
            dbConnection.SetCommand("SELECT time from kiosk.usage_time ORDER BY time DESC");

            MySqlDataReader reader = dbConnection.ExecuteQuery();
            TimeSpan time = new TimeSpan(0, 0, 0);

            while (reader.Read())
            {
                time = time.Add(TimeSpan.Parse(reader["time"].ToString()));
               break;
            }

          return time;
        }

        public void AddUsageTime(TimeSpan usageTime)
        {
            DbConnection dbConnection = new DbConnection();

            dbConnection.Connect();
            dbConnection.SetCommand("INSERT INTO kiosk.usage_time (`time`) VALUES ('" + usageTime.ToString() + "');");

            dbConnection.Execute();
            dbConnection.CloseConnection();
        }
    }
}

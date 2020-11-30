using EggDrop_Kiosk.Core.Order.Model;
using EggDrop_Kiosk.Core.Table.ViewModel;
using EggDrop_Kiosk.Core.Util;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggDrop_Kiosk.Core.Complete.Service
{
    class ReceiptService
    {
        string userName = "";
        string userId = "";
        int orderIdx = 0;

        public void GetUserName(string userId)
        {
            this.userId = userId;

            DbConnection dbConnection = new DbConnection();
            dbConnection.Connect();

            dbConnection.SetCommand("SELECT * FROM kiosk.member WHERE id = '" + userId + "'");

            MySqlDataReader reader = dbConnection.ExecuteQuery();


            while(reader.Read())
            {
                userName = reader["name"].ToString();
            }

            dbConnection.CloseConnection();
        }

        public void GetUserId(string userName)
        {
            this.userName = userName;

            DbConnection dbConnection = new DbConnection();
            dbConnection.Connect();

            dbConnection.SetCommand("SELECT * FROM kiosk.member WHERE name = '" + userName + "'");

            MySqlDataReader reader = dbConnection.ExecuteQuery();

            while(reader.Read())
            {
                userId = reader["id"].ToString();
            }

            dbConnection.CloseConnection();
        }

        public int PostReceipt(int isCard, int tableNumber, ObservableCollection<ProductModel> productModels)
        {
            DbConnection dbConnection = new DbConnection();
            dbConnection.Connect();

            dbConnection.SetCommand("INSERT INTO kiosk.receipt (created_at) VALUES ('" + DateTime.Now.ToString("yyyy:MM:dd HH:mm:ss") + "')");
            dbConnection.Execute();

            dbConnection.CloseConnection();

            dbConnection.Connect();

            dbConnection.SetCommand("SELECT max(idx) FROM kiosk.receipt");

            MySqlDataReader reader = dbConnection.ExecuteQuery();


            while (reader.Read())
            {
                orderIdx = Convert.ToInt32(reader["max(idx)"]);
            }

            dbConnection.CloseConnection();


            foreach (ProductModel product in productModels)
            {
                dbConnection.Connect();
                dbConnection.SetCommand("INSERT INTO kiosk.order_info (user_name, user_id, is_card," +
                    "table_number, product_idx, product_count, price, sale_percent, order_idx, created_at)" +
                    "VALUES ('" + userId + "','" + userName + "','" + isCard + "','" + tableNumber + "','" + product.Idx + "','" + product.Count + "','" + product.Price + "','" + product.SalePercent +
                    "','" + orderIdx + "','" + DateTime.Now.ToString("yyyy:MM:dd HH:mm:ss") + "')");

                dbConnection.Execute();
                dbConnection.CloseConnection();
            }

            return orderIdx;

        }
    }
}

using EggDrop_Kiosk.Core.Admin.Model;
using EggDrop_Kiosk.Core.Order.Model;
using EggDrop_Kiosk.Core.Util;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggDrop_Kiosk.Core.Admin.Service
{
    class OrderInfoService
    {

        public ObservableCollection<OrderInfoModel> GetOrderInfoModels()
        {
            DbConnection dbConnection = new DbConnection();

            dbConnection.Connect();
            dbConnection.SetCommand("SELECT * from order_info");

            MySqlDataReader reader = dbConnection.ExecuteQuery();

            ObservableCollection<OrderInfoModel> orderInfoModels = new ObservableCollection<OrderInfoModel>();

            while (reader.Read())
            {
                int idx = Convert.ToInt32(reader["product_idx"]);
                int price = Convert.ToInt32(reader["price"]);
                int salePercent = Convert.ToInt32(reader["sale_percent"]);
                int count = Convert.ToInt32(reader["product_count"]);

                OrderInfoModel orderInfoModel = new OrderInfoModel()
                {
                    OrderIdx = Convert.ToInt32(reader["order_idx"]),
                    UserId = Convert.ToString(reader["user_id"]),
                    UserName = Convert.ToString(reader["user_name"]),
                    Product = GetProductModel(idx, price, salePercent, count),
                    CreatedAt = Convert.ToDateTime(reader["created_at"].ToString()),
                    IsCard = Convert.ToBoolean(reader["is_card"]),
                };

                if (reader["table_number"].ToString() != "")
                {
                    orderInfoModel.TableNumber = Convert.ToInt32(reader["table_number"]); 
                }

                orderInfoModels.Add(orderInfoModel);
            }

            dbConnection.CloseConnection();

            return orderInfoModels;
        }

        private ProductModel GetProductModel(int idx, int price, int salePercent, int count)
        {
            DbConnection dbConnection = new DbConnection();
            dbConnection.Connect();

            dbConnection.SetCommand(String.Format("SELECT * from product WHERE idx = {0}", idx));

            MySqlDataReader reader = dbConnection.ExecuteQuery();

            ProductModel productModel = new ProductModel();

            while(reader.Read())
            {
                productModel = new ProductModel()
                {
                    Idx = Convert.ToInt32(reader["idx"]),
                    Name = Convert.ToString(reader["name"]),
                    CategoryIdx = Convert.ToInt32(reader["category_idx"]),
                    Price = price,
                    SalePercent = salePercent,
                    ImagePath = Convert.ToString(reader["image_path"]),
                    Count = count,
                    IsSoldOut = Convert.ToBoolean(reader["is_sold_out"]),
                    Page = 0
                };
            }
            dbConnection.CloseConnection();

            return productModel;
        }
    }
}

using EggDrop_Kiosk.Core.Order.Model;
using EggDrop_Kiosk.Core.Util;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggDrop_Kiosk.Core.Order.Service
{
    class CategoryService
    {
        public ObservableCollection<CategoryModel> GetCategories()
        {
            DbConnection dbConnection = new DbConnection();

            dbConnection.Connect();
            dbConnection.SetCommand("SELECT idx, name FROM category;");

            MySqlDataReader reader = dbConnection.ExecuteQuery();

            ObservableCollection<CategoryModel> categories = new ObservableCollection<CategoryModel>();
            while (reader.Read())
            {
                CategoryModel category = new CategoryModel()
                {
                    Idx = Convert.ToInt32(reader["idx"]),
                    Name = Convert.ToString(reader["name"])
                };

                categories.Add(category);
            }

            dbConnection.CloseConnection();

            return categories;
        }
    }
}

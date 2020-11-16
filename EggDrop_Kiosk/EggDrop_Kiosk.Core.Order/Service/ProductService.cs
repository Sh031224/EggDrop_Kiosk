﻿using EggDrop_Kiosk.Core.Order.Model;
using EggDrop_Kiosk.Core.Util;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggDrop_Kiosk.Core.Order.Service
{
    class ProductService
    {
        // 한 페이지 당 상품의 개수
        private const int PRODUCT_COUNT_FOR_PAGE = 6;

        public ObservableCollection<ProductModel> GetProducts()
        {
            DbConnection dbConnection = new DbConnection();

            dbConnection.Connect();
            // 카테고리 인덱스로 정렬해서 받아옴
            dbConnection.SetCommand("SELECT * FROM product ORDER BY category_idx;");

            MySqlDataReader reader = dbConnection.ExecuteQuery();

            ObservableCollection<ProductModel> products = new ObservableCollection<ProductModel>();


            int idx = 1;
            int categoryIdx = 0;

            while (reader.Read())
            {

                // 카테고리 순으로 정렬해서 받아왔기 때문에 카테고리가 바뀌면 페이지 계산을 위한 idx 초기화
                if (categoryIdx != Convert.ToInt32(reader["category_idx"]))
                {
                    categoryIdx = Convert.ToInt32(reader["category_idx"]);
                    idx = 1;
                }
                int page = Convert.ToInt32(idx / (PRODUCT_COUNT_FOR_PAGE + 1)) + 1;

                ProductModel product = new ProductModel()
                {
                    Idx = Convert.ToInt32(reader["idx"]),
                    Name = Convert.ToString(reader["name"]),
                    CategoryIdx = Convert.ToInt32(reader["category_idx"]),
                    Price = Convert.ToInt32(reader["price"]),
                    SalePercent = Convert.ToInt32(reader["sale_percent"]),
                    ImagePath = Convert.ToString(reader["image_path"]),
                    Count = 1,
                    IsSoldOut = Convert.ToBoolean(reader["is_sold_out"]),
                    Page = page
                };

                products.Add(product);
                idx++;
            }

            dbConnection.CloseConnection();

            return products;
        }
    }
}

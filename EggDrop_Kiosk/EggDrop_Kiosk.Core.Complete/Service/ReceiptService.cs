using EggDrop_Kiosk.Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggDrop_Kiosk.Core.Complete.Service
{
    class ReceiptService
    {
        public void PostReceipt()
        {
            DbConnection dbConnection = new DbConnection();

            dbConnection.Connect();
            dbConnection.SetCommand("INSERT INTO receipt (user_name, card_number, pay," +
                "table_number, product_idx, product_count, category_idx, price, sale_price)" +
                "VALUES ('" + "김봉팔" + "','" + "21esada" + "','" + "H" +
                "','" + 20 + "','" + 1 + "','" + 3 +"','" + 1 + "','" + 3000 +
                "','" + 2000 + "')");

            dbConnection.Execute();
            dbConnection.CloseConnection();
        }
    }
}

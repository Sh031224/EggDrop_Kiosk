using EggDrop_Kiosk.Core.Table.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggDrop_Kiosk.Core.Table.ViewModel
{
    public class TableViewModel
    {
        private static TableViewModel instance;
        private TableViewModel() { }

        public static TableViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TableViewModel();
                }

                return instance;
            }
        }

        public TableModel SelectedTable;

        public List<TableModel> tables = new List<TableModel>(new TableModel[]
        {
            new TableModel() { Number = 1 },
            new TableModel() { Number = 2 },
            new TableModel() { Number = 3 },
            new TableModel() { Number = 4 },
            new TableModel() { Number = 5 },
            new TableModel() { Number = 6 },
            new TableModel() { Number = 7 },
            new TableModel() { Number = 8 },
            new TableModel() { Number = 9 },
        });

        public void InitInstance()
        {
            SelectedTable = null;
        }
    }
}

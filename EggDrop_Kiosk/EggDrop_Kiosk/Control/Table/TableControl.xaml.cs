using EggDrop_Kiosk.Core.Table.Model;
using EggDrop_Kiosk.Core.Table.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UIStateManagerLibrary;

namespace EggDrop_Kiosk.Control.Table
{
    /// <summary>
    /// TableControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TableControl : CustomControlModel
    {
        private TableViewModel tableViewModel = TableViewModel.Instance;

        public TableControl()
        {
            InitializeComponent();
            tableList.ItemsSource = tableViewModel.tables;
        }

        private void tableList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tableList.SelectedIndex == -1) return;

            TableModel table = (TableModel)tableList.SelectedItem;

            if (table.IsUsing)
            {
                MessageBox.Show("이미 사용중인 테이블입니다.");
                tableList.SelectedIndex = -1;
                return;
            }

            tableViewModel.SelectedTable = table;
        }

        private void BtnTablePrevious_Click(object sender, RoutedEventArgs e)
        {
            App.uIStateManager.SwitchCustomControl(CustomControlType.PLACE);
        }

        private void BtnTableNext_Click(object sender, RoutedEventArgs e)
        {
            if (tableViewModel.SelectedTable == null)
            {
                MessageBox.Show("테이블을 선택해주세요.");
                return;
            }
            tableList.SelectedItem = null;
            App.uIStateManager.SwitchCustomControl(CustomControlType.PAY);
        }
    }
}

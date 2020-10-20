using EggDrop_Kiosk.Core.Order.Model;
using EggDrop_Kiosk.Core.Order.ViewModel;
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
using System.Windows.Threading;

namespace EggDrop_Kiosk.Control.Order
{
    /// <summary>
    /// UserControl1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class OrderControl : UserControl
    {
        private int page = 1;
        private int categoryIdx = 1;
        private OrderViewModel orderViewModel = App.orderData.orderViewModel;

        public OrderControl()
        {
            InitializeComponent();

            Loaded += OrderControl_Loaded;
        }

        private void OrderControl_Loaded(object sender, RoutedEventArgs e)
        {
            
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate ()
            {
                lbCategories.ItemsSource = App.orderData.orderViewModel.CategoryModels;
                lbCategories.SelectedIndex = 0;

                lbMenus.ItemsSource = orderViewModel.ProductModels.Where(x => x.CategoryIdx == categoryIdx && x.Page == page);

                lvOrdered.ItemsSource = App.orderData.orderViewModel.OrderedProductModels;
            }));
        }

        // 카테고리 메뉴 변경
        private void lbCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbCategories.SelectedIndex == -1)
            {
                return;
            }

            categoryIdx = lbCategories.SelectedIndex + 1;
            page = 1;
            lbMenus.ItemsSource = orderViewModel.ProductModels.Where(x => x.CategoryIdx == categoryIdx && x.Page == page);
        }

        private void BtnNextPage_Click(object sender, RoutedEventArgs e)
        {
            // 다음 페이지의 리스트가 존재하는지 확인
            if (orderViewModel.ProductModels.Where(x => x.CategoryIdx == categoryIdx && x.Page == page + 1).ToList().Count > 0)
            {
                page++;
                lbMenus.ItemsSource = orderViewModel.ProductModels.Where(x => x.CategoryIdx == categoryIdx && x.Page == page);
            }
        }

        private void BtnPrevPage_Click(object sender, RoutedEventArgs e)
        {
            // 이전 페이지의 리스트가 존재하는지 확인
            if (orderViewModel.ProductModels.Where(x => x.CategoryIdx == categoryIdx && x.Page == page - 1).ToList().Count > 0)
            {
                page--;
                lbMenus.ItemsSource = orderViewModel.ProductModels.Where(x => x.CategoryIdx == categoryIdx && x.Page == page);
            }
        }

        private void lbMenus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbMenus.SelectedItem != null)
            {
                ProductModel orderedProductModel = (ProductModel)lbMenus.SelectedItem;

                orderedProductModel.Count = 1;
                AddOrderedProductModels(orderedProductModel);
            }
        }

        private void AddOrderedProductModels(ProductModel orderedProductModel)
        {
            Console.WriteLine(App.orderData.orderViewModel.OrderedProductModels.Where(x => x.Name == orderedProductModel.Name));
            // 이미 있는 상품 클릭시 추가하지 않음
            if (App.orderData.orderViewModel.OrderedProductModels.Where(x => x.Name == orderedProductModel.Name).Count() > 0)
            {
                return;
            }
            App.orderData.orderViewModel.OrderedProductModels.Add(orderedProductModel);
        }
    }
}

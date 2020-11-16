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
using UIStateManagerLibrary;

namespace EggDrop_Kiosk.Control.Order
{
    /// <summary>
    /// UserControl1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class OrderControl : CustomControlModel
    {
        private int page = 1;
        private int categoryIdx = 1;

        public OrderControl()
        {
            InitializeComponent();

            Loaded += OrderControl_Loaded;
        }

        private void OrderControl_Loaded(object sender, RoutedEventArgs e)
        {
            
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate ()
            {
                lbCategories.ItemsSource = App.orderViewModel.CategoryModels;
                lbCategories.SelectedIndex = 0;

                lbMenus.ItemsSource = App.orderViewModel.ProductModels.Where(x => x.CategoryIdx == categoryIdx && x.Page == page);

                dgOrderedProducts.ItemsSource = App.orderViewModel.OrderedProductModels;
                tbTotalPrice.DataContext = App.orderViewModel;
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
            lbMenus.ItemsSource = App.orderViewModel.ProductModels.Where(x => x.CategoryIdx == categoryIdx && x.Page == page);
        }

        private void BtnNextPage_Click(object sender, RoutedEventArgs e)
        {
            // 다음 페이지의 리스트가 존재하는지 확인
            if (App.orderViewModel.ProductModels.Where(x => x.CategoryIdx == categoryIdx && x.Page == page + 1).ToList().Count > 0)
            {
                page++;
                lbMenus.ItemsSource = App.orderViewModel.ProductModels.Where(x => x.CategoryIdx == categoryIdx && x.Page == page);
            }
        }

        private void BtnPrevPage_Click(object sender, RoutedEventArgs e)
        {
            // 이전 페이지의 리스트가 존재하는지 확인
            if (App.orderViewModel.ProductModels.Where(x => x.CategoryIdx == categoryIdx && x.Page == page - 1).ToList().Count > 0)
            {
                page--;
                lbMenus.ItemsSource = App.orderViewModel.ProductModels.Where(x => x.CategoryIdx == categoryIdx && x.Page == page);
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

        private void PlusOrderedProduct(object sender, RoutedEventArgs e)
        {
            App.orderViewModel.PlusOrderedProductModels((ProductModel)dgOrderedProducts.SelectedItem);
        }

        private void MinusOrderedProduct(object sender, RoutedEventArgs e)
        {
            App.orderViewModel.MinusOrderedProductModels((ProductModel)dgOrderedProducts.SelectedItem);
        }
        private void AddOrderedProductModels(ProductModel orderedProductModel)
        {
            App.orderViewModel.AddOrderedProductModels(orderedProductModel);
        }

        private void RemoveOrderedProduct(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("정말로 지우시겠습니까?", "경고", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                App.orderViewModel.RemoveOrderedProductModels((ProductModel)dgOrderedProducts.SelectedItem);
            }
        }

        private void BtnClearOrderedProduct_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("정말로 모두 삭제하시겠습니까?", "경고", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                App.orderViewModel.ClearOrderedProductModels();
            }
        }

        private void BtnOrderNext_Click(object sender, RoutedEventArgs e)
        {
            if (App.orderViewModel.OrderedProductModels.Count() == 0)
            {
                MessageBox.Show("상품이 없습니다.");
                return;
            }

            lbMenus.SelectedItem = null;
            App.uIStateManager.SwitchCustomControl(CustomControlType.PLACE);
        }
    }
}

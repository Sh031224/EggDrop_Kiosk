using EggDrop_Kiosk.Core.Order.Model;
using EggDrop_Kiosk.Core.Order.Service;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace EggDrop_Kiosk.Core.Order.ViewModel
{
    public class OrderViewModel: BindableBase
    {
        private CategoryService categoryService = new CategoryService();
        private ProductService productService = new ProductService();

        private ObservableCollection<CategoryModel> _categoryModels = new ObservableCollection<CategoryModel>();
        public ObservableCollection<CategoryModel> CategoryModels
        {
            get => _categoryModels;
            set => SetProperty(ref _categoryModels, value);
        }

        private ObservableCollection<ProductModel> _productModels = new ObservableCollection<ProductModel>();
        public ObservableCollection<ProductModel> ProductModels
        {
            get => _productModels;
            set => SetProperty(ref _productModels, value);
        }

        private ObservableCollection<ProductModel> _orderedProductModels = new ObservableCollection<ProductModel>();
        public ObservableCollection<ProductModel> OrderedProductModels
        {
            get => _orderedProductModels;
            set => SetProperty(ref _orderedProductModels, value);
        }

        // 병렬로 모든 데이터 로드
        public void LoadData()
        {
            LoadCategoryData();
            LoadProductData();
        }

        // 카테고리 로딩
        private void LoadCategoryData()
        {
            CategoryModels = categoryService.GetCategories();
        }

        // 상품 로딩
        private  void LoadProductData()
        {
            ProductModels = productService.GetProducts();
        }
    }
}

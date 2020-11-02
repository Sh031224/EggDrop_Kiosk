using EggDrop_Kiosk.Core.Order.Model;
using EggDrop_Kiosk.Core.Order.Service;
using EggDrop_Kiosk.Core.Util.lib;
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

        public ObservableData<int> OrderedTotalPrice = new ObservableData<int>();
  
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

        private TrulyObservableCollection<ProductModel> _orderedProductModels = new TrulyObservableCollection<ProductModel>();
        public TrulyObservableCollection<ProductModel> OrderedProductModels
        {
            get => _orderedProductModels;
            set => SetProperty(ref _orderedProductModels, value);
        }

        public void LoadData()
        {
            LoadCategoryData();
            LoadProductData();
            OrderedTotalPrice.Value = 0;
            OrderedProductModels.CollectionChanged += OrderedProductModels_CollectionChanged;
        }

        private void OrderedProductModels_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            int total = 0;
            foreach (ProductModel product in OrderedProductModels)
            {
                total += product.TotalPrice;
            }
            OrderedTotalPrice.Value = total;
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

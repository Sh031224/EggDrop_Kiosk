using EggDrop_Kiosk.Core.Order.Model;
using EggDrop_Kiosk.Core.Order.Service;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace EggDrop_Kiosk.Core.Order.ViewModel
{
    public class OrderViewModel: BindableBase
    {
        private CategoryService categoryService = new CategoryService();
        private ProductService productService = new ProductService();

        private int _orderedTotalPrice = 0;
        public int OrderedTotalPrice
        {
            get => _orderedTotalPrice;
            set => SetProperty(ref _orderedTotalPrice, value);
        }
  
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
        private void LoadProductData()
        {
            ProductModels = productService.GetProducts();
        }

        private void CalcTotalPrice()
        {
            int total = 0;
            foreach (ProductModel product in OrderedProductModels)
            {
                total += product.TotalPrice;
            }
            OrderedTotalPrice = total;
        }

        public void AddOrderedProductModels(ProductModel productModel)
        {
            // 이미 있는 상품 클릭시 추가하지 않음
            if (OrderedProductModels.Where(x => x.Name == productModel.Name).Count() > 0)
            {
                return;
            }
            OrderedProductModels.Add(productModel);
            CalcTotalPrice();
        }

        public void RemoveOrderedProductModels(ProductModel productModel)
        {
            OrderedProductModels.Remove(productModel);
            CalcTotalPrice();
        }

        public void ClearOrderedProductModels()
        {
            OrderedProductModels.Clear();
            CalcTotalPrice();
        }

        public void PlusOrderedProductModels(ProductModel productModel)
        {
            OrderedProductModels.Where(x => x == productModel).ToList()[0].Count += 1;
            CalcTotalPrice();
        }

        public void MinusOrderedProductModels(ProductModel productModel)
        {
            if (OrderedProductModels.Where(x => x == productModel).ToList()[0].Count != 1)
            {
                OrderedProductModels.Where(x => x == productModel).ToList()[0].Count -= 1;
                CalcTotalPrice();
            }
        }
    }
}

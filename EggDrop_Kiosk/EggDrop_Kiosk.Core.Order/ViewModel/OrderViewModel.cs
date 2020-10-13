using EggDrop_Kiosk.Core.Order.Model;
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
        private ObservableCollection<ProductModel> _productModels = new ObservableCollection<ProductModel>();
        public ObservableCollection<ProductModel> ProductModels
        {
            get => _productModels;
            set => SetProperty(ref _productModels, value);
        }

        private ObservableCollection<CategoryModel> _categoryModels = new ObservableCollection<CategoryModel>();
        public ObservableCollection<CategoryModel> CategoryModels
        {
            get => _categoryModels;
            set => SetProperty(ref _categoryModels, value);
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
            CategoryModels.Add(new CategoryModel() { Name = "샌드위치", Category = ECategory.SANDWICH });
            CategoryModels.Add(new CategoryModel() { Name = "커피", Category = ECategory.COFFEE });
            CategoryModels.Add(new CategoryModel() { Name = "라떼", Category = ECategory.LATTE });
        }

        // 상품 로딩
        private  void LoadProductData()
        {
            ProductModels.Add(new ProductModel() { Name = "미스터 에그", Category = ECategory.SANDWICH, Count = 0, ImagePath = @"/Assets/Order/Sandwich/Mr.Egg.PNG", Price = 3400, SalePercent = 0 });
            ProductModels.Add(new ProductModel() { Name = "아메리카 햄 치즈", Category = ECategory.SANDWICH, Count = 0, ImagePath = @"/Assets/Order/Sandwich/American Ham Cheese.PNG", Price = 3900, SalePercent = 0 });
            ProductModels.Add(new ProductModel() { Name = "베이컨 더블 치즈", Category = ECategory.SANDWICH, Count = 0, ImagePath = @"/Assets/Order/Sandwich/Bacon Dobuble Cheese.PNG", Price = 4200, SalePercent = 0 });
            ProductModels.Add(new ProductModel() { Name = "데리야끼 바베큐", Category = ECategory.SANDWICH, Count = 0, ImagePath = @"/Assets/Order/Sandwich/Teriyaki BBQ.PNG", Price = 4700, SalePercent = 0 });
            ProductModels.Add(new ProductModel() { Name = "아보 홀릭", Category = ECategory.SANDWICH, Count = 0, ImagePath = @"/Assets/Order/Sandwich/Avo Holic.PNG", Price = 4900, SalePercent = 0 });
            ProductModels.Add(new ProductModel() { Name = "타마고 산도", Category = ECategory.SANDWICH, Count = 0, ImagePath = @"/Assets/Order/Sandwich/Tamago Sando.PNG", Price = 3900, SalePercent = 0 });
            ProductModels.Add(new ProductModel() { Name = "에그 콥 샐러드", Category = ECategory.SANDWICH, Count = 0, ImagePath = @"/Assets/Order/Sandwich/Egg Cobb Salad.PNG", Price = 4400, SalePercent = 0 });
            ProductModels.Add(new ProductModel() { Name = "갈릭 베이컨 치즈", Category = ECategory.SANDWICH, Count = 0, ImagePath = @"/Assets/Order/Sandwich/Garlic Bacon Cheese.PNG", Price = 4400, SalePercent = 0 });
        }
    }
}

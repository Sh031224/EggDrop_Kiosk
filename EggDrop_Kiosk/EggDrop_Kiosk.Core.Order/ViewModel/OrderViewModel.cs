﻿using EggDrop_Kiosk.Core.Order.Model;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggDrop_Kiosk.Core.Order.ViewModel
{
    public class OrderViewModel: BindableBase
    {
        private bool _isLoading = false;
        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

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
            _isLoading = true;
            Parallel.Invoke(
                async () =>
                {
                    await LoadCategoryData();
                },
                async () =>
                {
                    await LoadProductData();
                }
            );
            _isLoading = false;
        }

        // 카테고리 로딩
        private async Task LoadCategoryData()
        {
            await Task.Run(() =>
            {
                _categoryModels.Add(new CategoryModel() { Name = "샌드위치", Category = ECategory.SANDWICH });
                _categoryModels.Add(new CategoryModel() { Name = "커피", Category = ECategory.COFFEE });
                _categoryModels.Add(new CategoryModel() { Name = "라떼", Category = ECategory.LATTE });
            });
        }

        // 상품 로딩
        private async Task LoadProductData()
        {
            await Task.Run(() =>
            {
                //_productModels.Add(new ProductModel() { Name = "베이컨 더블 치즈" })
            });
        }
    }
}

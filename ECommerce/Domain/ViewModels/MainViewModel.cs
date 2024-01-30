using ECommerce.Commands;
using ECommerce.DataAccess.SqlServer;
using ECommerce.Domain.Services;
using ECommerce.Domain.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ECommerce.Domain.ViewModels
{
    public class MainViewModel:BaseViewModel
    {
        public RelayCommand ToLowerCommand { get; set; }
        public RelayCommand SelectedProductCommand { get; set; }

        private readonly ProductService _productService;
        public MainViewModel()
        {
            FilterText = "Higher To Lower";
            _productService = new ProductService();

            AllProducts = _productService.GetFromHigherToLower(IsLower);

            ToLowerCommand = new RelayCommand((obj) =>
            {
                IsLower = !IsLower;
                if (IsLower)
                {
                    FilterText = "Higher To Lower";
                }
                else
                {
                    FilterText = "Lower To Higher";
                }

                AllProducts =_productService.GetFromHigherToLower(IsLower);
            });

            SelectedProductCommand = new RelayCommand((obj) =>
            {
                var vm = new ProductInfoViewModel();
                vm.ProductInfo = SelectedProduct;
                var view = new ProductWindow();
                view.DataContext = vm;
                view.ShowDialog();
               //// MessageBox.Show(SelectedProduct.Name);
            });
        }

        public bool IsLower { get; set; } = true;

        private ObservableCollection<Product> allProducts;

        public ObservableCollection<Product> AllProducts
        {
            get { return allProducts; }
            set { allProducts = value; OnPropertyChanged(); }
        }

        private string filterText;

        public string FilterText
        {
            get { return filterText; }
            set { filterText = value; OnPropertyChanged(); }
        }

        private Product selectedProduct;

        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set { selectedProduct = value; OnPropertyChanged(); }
        }



    }
}

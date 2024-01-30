using ECommerce.DataAccess.SqlServer;
using ECommerce.Domain.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.ViewModels
{
    public class MainViewModel:BaseViewModel
    {
        private readonly ProductService _productService;
        public MainViewModel()
        {
            _productService = new ProductService();

            AllProducts = _productService.GetFromHigherToLower(false);
        }


        private ObservableCollection<Product> allProducts;

        public ObservableCollection<Product> AllProducts
        {
            get { return allProducts; }
            set { allProducts = value; OnPropertyChanged(); }
        }

    }
}

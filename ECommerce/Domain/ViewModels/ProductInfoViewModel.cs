using ECommerce.Commands;
using ECommerce.DataAccess.SqlServer;
using ECommerce.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ECommerce.Domain.ViewModels
{
    public class ProductInfoViewModel:MainViewModel
    {
		private CustomerService _customerService;
		private OrderService _orderService;
		private ProductService _productService;
        public RelayCommand OrderCommand { get; set; }
        public ProductInfoViewModel()
        {
			_customerService=new CustomerService();
			_orderService=new OrderService();
			_productService=new ProductService();

			OrderCommand = new RelayCommand((obj) =>
			{
				var customer = _customerService.GetCustomerByUsername(Username);
				if(customer!= null)
				{
					if (Amount <= ProductInfo.Quantity)
					{
						ProductInfo.Quantity -= Amount;

						var order = new Order
						{
							Amount=amount,
							CustomerId = customer.Id,
							ProductId=ProductInfo.Id,
							Date=DateTime.Now,
						};

						_orderService.AddData(order);

						_productService.UpdateProduct(ProductInfo);

						MessageBox.Show("Your order submitted");
					}
					else
					{
						MessageBox.Show($"There is no {Amount} items in our stock");
					}
				}
				else
				{
					MessageBox.Show("User does not exist");
				}
			});
        }

        private Product productInfo;

		public Product ProductInfo
        {
			get { return productInfo; }
			set { productInfo = value; OnPropertyChanged(); }
		}


		private int amount;

		public int Amount
		{
			get { return amount; }
			set { amount = value; OnPropertyChanged(); }
		}

		private string username;

		public string Username
		{
			get { return username; }
			set { username = value; OnPropertyChanged(); }
		}


	}
}

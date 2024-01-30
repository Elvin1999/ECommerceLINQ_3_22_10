using ECommerce.DataAccess.Abstractions;
using ECommerce.DataAccess.SqlServer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private readonly EECommerceDataContext _context;

        public ProductRepository()
        {
            _context = new EECommerceDataContext();
        }

        public void AddData(Product data)
        {
            _context.Products.InsertOnSubmit(data);
            _context.SubmitChanges();
        }

        public void DeleteData(Product data)
        {
            _context.Products.DeleteOnSubmit(data);
            _context.SubmitChanges();
        }

        public ObservableCollection<Product> GetAll()
        {
            var products = from p in _context.Products
                           orderby p.Name
                           select p;
            return new ObservableCollection<Product>(products);
        }

        public Product GetData(int id)
        {
            return _context.Products.SingleOrDefault(x => x.Id == id);
        }

        public void UpdateData(Product data)
        {
            var item = _context.Products.SingleOrDefault(x => x.Id == data.Id);
            if (item != null)
            {
                item.Name = data.Name;
                item.Description = data.Description;
                item.Price = data.Price;
                item.Quantity = data.Quantity;
                item.Discount = data.Discount;
                _context.SubmitChanges();
            }

        }
    }
}

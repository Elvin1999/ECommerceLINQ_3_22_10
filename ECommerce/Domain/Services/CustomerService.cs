using ECommerce.DataAccess.Abstractions;
using ECommerce.DataAccess.Concrete;
using ECommerce.DataAccess.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Services
{
    public class CustomerService
    {
        private readonly ICustomerRepository _repository;
        public CustomerService()
        {
            _repository = new CustomerRepository();
        }
        public Customer GetCustomerByUsername(string username)
        {
            var customers=_repository.GetAll();
            var customer=customers.FirstOrDefault(c=>c.Username==username);
            return customer;
        }
    }
}

using ECommerce.DataAccess.Abstractions;
using ECommerce.DataAccess.Concrete;
using ECommerce.DataAccess.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService()
        {
            _orderRepository=new OrderRepository();
        }

        public void AddData(Order order)
        {
            _orderRepository.AddData(order);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DechkoWebApp.Infrastructure.Domain;


namespace DechkoWebApp.Core.Abstraction
{
  public interface IOrderService
    {
        bool Create(int productId, string userId, int quantity);

        List<Order> GetOrders();

        List<Order> GetOrdersByUserId(string userId);


    }
}

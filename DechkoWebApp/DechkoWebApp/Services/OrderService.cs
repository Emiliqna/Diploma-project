using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DechkoWebApp.Abstraction;
using DechkoWebApp.Data;
using DechkoWebApp.Domain;

namespace DechkoWebApp.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Create(int productId, string userId, int quantity)
        {
            //намираме продукта по неговото id
            var product = this._context.Products.SingleOrDefault(x => x.Id == productId);

            //проверяваме дали има  такъв продукт
            if (product == null)
            {
                return false;
            }

            //създаване на поръчка
            Order item = new Order
            {
                OrderDate = DateTime.Now,
                ProductId = productId,
                UserId = userId,
                Quantity = quantity,
                Price = product.Price,
                Discount = product.Discount,
            };

            //намаляване на количеството на продукта
            product.Quantity -= quantity;

            //отразяване на промените в колекциите
            this._context.Products.Update(product);
            this._context.Orders.Add(item);

            //запис на промените в БД
            return _context.SaveChanges() != 0;
        }

        public List<Order> GetOrders()
        {
            return _context.Orders.OrderByDescending(x => x.OrderDate).ToList();
        }

        public List<Order> GetOrdersByUserId(string userId)
        {
            return _context.Orders.Where(x => x.UserId == userId)
    .OrderByDescending(x => x.OrderDate)
    .ToList();
        }
    }

}
    

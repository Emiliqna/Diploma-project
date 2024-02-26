using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;

using DechkoWebApp.Core.Abstraction;
using DechkoWebApp.Infrastructure.Domain;
using DechkoWebApp.Models.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DechkoWebApp.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;

        public OrderController(IProductService productService, IOrderService orderService)
        {
            _productService = productService;
            _orderService = orderService;
        }
        // GET: OrderController
        //Създава списък за направените поръчки от всички потребители

        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            // string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //  var user = context.Users.SingleOrDefault(u => u.Id == userId);

            List<OrderIndexVM> orders = _orderService.GetOrders()
                .Select(x => new OrderIndexVM
                {
                    Id = x.Id,
                    OrderDate = x.OrderDate.ToString("dd-MMM-yyyy hh:mm", CultureInfo.InvariantCulture),
                    UserId = x.UserId,
                    User = x.User.UserName,
                    ProductId = x.ProductId,
                    ProductName = x.Product.Name,
                    Picture = x.Product.Picture,
                    Quantity = x.Quantity,
                    Price = x.Price,
                    Discount = x.Discount,
                    TotalPrice = x.TotalPrice,
                }).ToList();
            return View(orders);
        }


        //Служи за показване на направените от клиента(потребител) поръчки
        public ActionResult MyOrders()
        {
            string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //  var user = context.Users.SingleOrDefault(u => u.Id == userId);

            List<OrderIndexVM> orders = _orderService.GetOrdersByUserId(currentUserId)
                .Select(x => new OrderIndexVM
                {
                    Id = x.Id,
                    OrderDate = x.OrderDate.ToString("dd-MMM-yyyy hh:mm", CultureInfo.InvariantCulture),
                    UserId = x.UserId,
                    User = x.User.UserName,
                    ProductId = x.ProductId,
                    ProductName = x.Product.Name,
                    Picture = x.Product.Picture,
                    Quantity = x.Quantity,
                    Price = x.Price,
                    Discount = x.Discount,
                    TotalPrice = x.TotalPrice,
                }).ToList();
            return View(orders);
        }
        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //Служи за създаване и потвърждаване на поръчка
        // GET: OrderController/Create
        public ActionResult Create(int productId, int quantity)
        {
            Product product = _productService.GetProductById(productId);
            if (product == null)
            {
                return NotFound();
            }
            OrderConfirmVM orderForDb = new OrderConfirmVM
            {
                //Id = x.Id,
                ProductId = productId,
                ProductName = product.Name,
                Picture = product.Picture,
                Description = product.Description,
                Quantity = quantity,
                Price = product.Price,
                Discount = product.Discount,
                TotalPrice = quantity * product.Price - quantity * product.Price * product.Discount / 100


            };
            return View(orderForDb);
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderConfirmVM bindingModel)
        {
            if (this.ModelState.IsValid)
            {
                string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

                var product = this._productService.GetProductById(bindingModel.ProductId);
                if (currentUserId == null || product == null || product.Quantity < bindingModel.Quantity || product.Quantity == 0)
                {
                    return this.RedirectToAction("Index", "Product");
                }

                _orderService.Create(bindingModel.ProductId, currentUserId, bindingModel.Quantity);

                //при успешна поръчка се връща в списъка на продуктите
                return this.RedirectToAction("Index", "Product");
            }
            return this.RedirectToAction("Index", "Product");

        }
    }
}



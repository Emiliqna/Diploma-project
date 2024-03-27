using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DechkoWebApp.Infrastructure.Domain;

namespace DechkoWebApp.Core.Abstraction
{
   public interface IProductService
    {
        bool Create(string name, int categoryId, int brandId, string description,
            string picture, decimal price, int quantity, decimal discount);
        bool Update(int productId, string name, int categoryId, int brandId, 
            string description, string picture, decimal price, int quantity, decimal discount);
        List<Product> GetProducts();
        Product GetProductById(int productId);
        bool RemoveProductById(int productId);
        List<Product> GetProducts(string searchStringCategoryName, string searchStringBrandName);
    }
}

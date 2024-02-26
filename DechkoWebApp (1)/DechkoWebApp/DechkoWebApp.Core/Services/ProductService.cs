using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DechkoWebApp.Core.Abstraction;
using DechkoWebApp.Infrastructure.Data;
using DechkoWebApp.Infrastructure.Domain;

namespace DechkoWebApp.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Create(string name, int categoryId, int brandId, string description, string picture, decimal price, int quantity, decimal discount)
        {
            Product item = new Product
            {
                Name = name,

                Category = _context.Categories.Find(categoryId),
                Brand = _context.Brands.Find(brandId),

                Description = description,
                Picture = picture,
                Price = price,
                Quantity = quantity,
                Discount = discount

            };

            _context.Products.Add(item);
            return _context.SaveChanges() != 0;
        }

        public Product GetProductById(int productId)
        {
            return _context.Products.Find(productId);
        }

        public List<Product> GetProducts()
        {
            List<Product> products = _context.Products.ToList();
            return products;
        }

        public List<Product> GetProducts(string searchStringCategoryName, string searchStringBrandName)
        {
            List<Product> products = _context.Products.ToList();
            if (!String.IsNullOrEmpty(searchStringCategoryName) && !String.IsNullOrEmpty(searchStringBrandName))
            {
                products = products.Where(x => x.Category.Name.ToLower().Contains(searchStringCategoryName.ToLower())
                && x.Brand.Name.ToLower().Contains(searchStringBrandName.ToLower())).ToList();
            }
            else if (!String.IsNullOrEmpty(searchStringCategoryName))
            {
                products = products.Where(x => x.Category.Name.ToLower().Contains(searchStringCategoryName.ToLower())).ToList();
            }
            else if (!String.IsNullOrEmpty(searchStringBrandName))
            {
                products = products.Where(x => x.Brand.Name.ToLower().Contains(searchStringBrandName.ToLower())).ToList();
            }
            return products;
        }

        public bool RemoveProductById(int productId)
        {
            var product = GetProductById(productId);
            if (product == default(Product))
            {
                return false;
            }

            _context.Remove(product);
            return _context.SaveChanges() != 0;
        }

        public bool Update(int productId, string name, int categoryId, int brandId, string description, string picture, decimal price, int quantity, decimal discount)
        {
            var product = GetProductById(productId);
            if (product == default(Product))
            {
                return false;
            }

            product.Name = name;



            product.BrandId = brandId;
            product.CategoryId = categoryId;

            product.Brand = _context.Brands.Find(brandId);
            product.Category = _context.Categories.Find(categoryId);

            product.Description = description;
            product.Picture = picture;
            product.Price = price;
            product.Quantity = quantity;
            product.Discount = discount;
            _context.Update(product);
            return _context.SaveChanges() != 0;
        }
    }
}

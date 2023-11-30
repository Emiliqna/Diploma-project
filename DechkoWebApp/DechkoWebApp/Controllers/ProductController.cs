using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DechkoWebApp.Abstraction;
using DechkoWebApp.Domain;
using DechkoWebApp.Models.Brand;
using DechkoWebApp.Models.Category;
using DechkoWebApp.Models.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DechkoWebApp.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IBrandService _brandService;

        public ProductController(IProductService productService, ICategoryService categoryService, IBrandService brandService)
        {
            this._productService = productService;
            this._categoryService = categoryService;
            this._brandService = brandService;
        }

        // GET: ProductController
        [AllowAnonymous]
        public ActionResult Index(string searchStringCategoryName, string searchStringBrandName)
        {
            List<ProductIndexVM> products = _productService.GetProducts(searchStringCategoryName, searchStringBrandName)
                 .Select(product => new ProductIndexVM
                 {
                     Id = product.Id,
                     Name = product.Name,
                     CategoryId = product.CategoryId,
                     CategoryName = product.Category.Name,
                     BrandId = product.BrandId,
                     BrandName = product.Brand.Name,
                     Description = product.Description,
                     Picture = product.Picture,
                     Price = product.Price,
                     Quantity = product.Quantity,
                     Discount = product.Discount

                 }).ToList();
            return this.View(products);
        }

        // GET: ProductController/Details/5
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            Product item = _productService.GetProductById(id);
            if (item == null)
            {
                return NotFound();
            }
            ProductDetailsVM product = new ProductDetailsVM()
            {
                Id = item.Id,
                Name = item.Name,
                CategoryId = item.CategoryId,
                CategoryName = item.Category.Name,
                BrandId = item.BrandId,
                BrandName = item.Brand.Name,
                Description = item.Description,
                Picture = item.Picture,
                Price = item.Price,
                Quantity = item.Quantity,
                Discount = item.Discount



            };
            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            var product = new ProductCreateVM();
            product.Brands = _brandService.GetBrands()
                .Select(x => new BrandPairVM()
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();
            product.Categories = _categoryService.GetCategories()
                .Select(x => new CategoryPairVM()
                {
                    Id = x.Id,
                    Name = x.Name,
                }).ToList();
            return View(product);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] ProductCreateVM product)
        {
            if (ModelState.IsValid)
            {
                var createId = _productService.Create(product.Name, 
                                                      product.CategoryId, product.BrandId, product.Description, product.Picture,
                                                     product.Price, product.Quantity,  product.Discount);
                if (createId)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View();
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            Product product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            ProductEditVM updatedProduct = new ProductEditVM()
            {
                Id = product.Id,
                Name = product.Name,
                CategoryId = product.CategoryId,
                BrandId = product.BrandId,
                Description = product.Description,
                Picture = product.Picture,
                Price = product.Price,
                Quantity = product.Quantity,
                Discount = product.Discount

            };
            updatedProduct.Brands = _brandService.GetBrands()
                .Select(b => new BrandPairVM()
                {
                    Id = b.Id,
                    Name = b.Name
                })
                .ToList();

            updatedProduct.Categories = _categoryService.GetCategories()
                .Select(b => new CategoryPairVM()
                {
                    Id = b.Id,
                    Name = b.Name
                })
                .ToList();
            return View(updatedProduct);
        }

            // POST: ProductController/Edit/5
            [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductEditVM product)
        {
            if (ModelState.IsValid)
            {
                var updated = _productService.Update(id, product.Name, product.CategoryId, product.BrandId,
                                                     product.Description, product.Picture, product.Price, product.Quantity, product.Discount);
                if (updated)
                {
                    return this.RedirectToAction("Index");
                }
            }
            return View(product);
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            Product item = _productService.GetProductById(id);
            if (item == null)
            {
                return NotFound();
            }

            ProductDeleteVM product = new ProductDeleteVM()
            {
                Id = item.Id,
                Name = item.Name,
                CategoryId = item.CategoryId,
                BrandId = item.BrandId,
                Description = item.Description,
                Picture = item.Picture,
                Price = item.Price,
                Quantity = item.Quantity,
                Discount = item.Discount

            };
            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var deleted = _productService.RemoveProductById(id);

            if (deleted)
            {
                return this.RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DechkoWebApp.Domain;

namespace DechkoWebApp.Abstraction
{
   public interface ICategoryService
    {
        List<Category> GetCategories();
        Category GetCategoryById(int categoryId);
        List<Product> GetProductsByCategory(int categoryId);
    }
}

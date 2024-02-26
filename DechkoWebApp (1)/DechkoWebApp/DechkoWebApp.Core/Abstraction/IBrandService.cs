using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DechkoWebApp.Infrastructure.Domain;

namespace DechkoWebApp.Core.Abstraction
{
    public interface IBrandService
    {
        List<Brand> GetBrands();
        Brand GetBrandById(int brandId);
        List<Product> GetProductsByBrand(int brandId);
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DechkoWebApp.Models.Product
{
    public class ProductDeleteVM
    {
        public int Id { get; set; }

        [Display(Name = "Product name")]
        public string Name { get; set; }


        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        [Display(Name = "Brand")]
        public int BrandId { get; set; }
        public string BrandName { get; set; }

        [Display(Name = "Description of product")]
        public string Description { get; set; }

        [Display(Name = "Product picture")]
        public string Picture { get; set; }

        [Display(Name = "Price")]
        public decimal Price { get; set; }


        public int Quantity { get; set; }

        public decimal Discount { get; set; }


    }
}

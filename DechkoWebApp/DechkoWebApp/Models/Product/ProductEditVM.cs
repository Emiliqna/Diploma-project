using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DechkoWebApp.Models.Brand;
using DechkoWebApp.Models.Category;

namespace DechkoWebApp.Models.Product
{
    public class ProductEditVM
    {
        
        
            [Required]
            [Key]
            public int Id { get; set; }

            [Required]
            [MinLength(5)]
            [MaxLength(30)]

           [Display(Name = "Име на продукта")]
            public string Name { get; set; }

        [Display(Name = "Категория")]
        [Required]
            public int CategoryId { get; set; }

            public virtual List<CategoryPairVM> Categories { get; set; } = new List<CategoryPairVM>();

        [Display(Name = "Марка")]
        [Required]
            public int BrandId { get; set; }
            public virtual List<BrandPairVM> Brands { get; set; } = new List<BrandPairVM>();

        [Display(Name = "Описание на продукта")]
            [Required]
            public string Description { get; set; }

        [Display(Name = "Снимка на продукта")]
            [Required]
            public string Picture { get; set; }

        [Display(Name = "Цена на продукта")]
            [Required]
            public decimal Price { get; set; }

        [Display(Name = "Наличност")]
            [Range(0, 1000)]
            public int Quantity { get; set; }

        [Display(Name = "Отстъпка")]
            public decimal Discount { get; set; }

            public ProductEditVM()
            {
                Brands = new List<BrandPairVM>();
                Categories = new List<CategoryPairVM>();
            }
        }
}

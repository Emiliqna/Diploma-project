using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DechkoWebApp.Models.Brand;
using DechkoWebApp.Models.Category;

namespace DechkoWebApp.Models.Product
{
    public class ProductCreateVM
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(30)]

        [Display(Name = "Име на продукта")]
        public string Name { get; set; }


        [Required]
        [Display(Name = "Категория")]
        public int CategoryId { get; set; }
       
        public virtual List<CategoryPairVM> Categories { get; set; }= new List<CategoryPairVM>();

        [Required]
        [Display(Name = "Марка")]
        public int BrandId { get; set; }
        public virtual List <BrandPairVM> Brands { get; set; }= new List<BrandPairVM>();

        [Required]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Снимка на продукта")]
        public string Picture { get; set; }

        [Required]
        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        [Range(0, 1000)]
        [Display(Name = "Наличност")]
        public int Quantity { get; set; }

        [Display(Name = "Отстъпка")]
        public decimal Discount { get; set; }

        public ProductCreateVM()
        {
            Brands = new List<BrandPairVM>();
            Categories = new List<CategoryPairVM>();
        }
    }
}

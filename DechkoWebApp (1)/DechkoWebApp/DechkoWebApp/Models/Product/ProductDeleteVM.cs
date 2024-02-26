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

        [Display(Name = "Име на продукта")]
        public string Name { get; set; }


        
        public int CategoryId { get; set; }

        [Display(Name = "Категория")]
        public string CategoryName { get; set; }

       
        public int BrandId { get; set; }

        [Display(Name = "Марка")]
        public string BrandName { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Снимка на продукта")]
        public string Picture { get; set; }

        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        [Display(Name = "Наличност")]
        public int Quantity { get; set; }

        [Display(Name = "Отстъпка")]
        public decimal Discount { get; set; }


    }
}

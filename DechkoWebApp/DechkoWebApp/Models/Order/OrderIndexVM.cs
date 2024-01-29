using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DechkoWebApp.Models.Order
{
    public class OrderIndexVM
    {
       
        public int Id { get; set; }

        [Display(Name = "Дата на поръчка")]
        public string OrderDate { get; set; }

        [Display(Name = "Снимка на продукта")]
        public string Picture { get; set; }
        public int ProductId { get; set; }

        [Display(Name = "Име на продукта")]
        public string ProductName { get; set; }

        
    
        public string UserId { get; set; }

        [Display(Name = "Потребител")]
        public string User { get; set; }


       
       
        [Display(Name = "Брой")]
        public int Quantity { get; set; }

       
        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        [Display(Name = "Отстъпка")]
        public decimal Discount { get; set; }

        [Display(Name = "Крайна цена")]
        public decimal TotalPrice { get; set; }
    }
}

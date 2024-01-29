using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DechkoWebApp.Models.Order
{
    public class OrderConfirmVM
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

      

        [Required]
        public int ProductId { get; set; }

        [Display(Name = "Име на продукта")]
        public string ProductName { get; set; }

        [Display(Name = "Снимка на продукта")]
        public string Picture { get; set; }

        [Required]
        [Display(Name = "Номер на потребител ")]
        public string UserId { get; set; }

        [Display(Name = "Потребител")]
        public string User { get; set; }

        [Display(Name = "Описание на продукта")]
        public string Description { get; set; }

        [Required]
        [Range(1,int.MaxValue)]
        [Display(Name = "Брой")]
        public int Quantity { get; set; }

        [Required]
        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        [Display(Name = "Отстъпка")]
        public decimal Discount { get; set; }

        [Display(Name = "Крайна цена")]
        public decimal TotalPrice { get; set; }
    }
}

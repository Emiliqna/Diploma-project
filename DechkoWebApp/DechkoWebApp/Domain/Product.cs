using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DechkoWebApp.Domain
{
    public class Product
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(30)]

        public string Name { get; set; }


        [Required]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [Required]
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Picture { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Range(0,1000)]
        public int Quantity { get; set; }

        public decimal Discount { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}

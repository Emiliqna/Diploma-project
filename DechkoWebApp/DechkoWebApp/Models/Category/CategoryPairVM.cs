using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DechkoWebApp.Models.Category
{
    public class CategoryPairVM
    {
        public int Id { get; set; }

        [Display(Name = "Категория")]
        public string Name { get; set; }
    }
}

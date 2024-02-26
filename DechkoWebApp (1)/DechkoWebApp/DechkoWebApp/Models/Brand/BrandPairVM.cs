using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DechkoWebApp.Models.Brand
{
    public class BrandPairVM
    {
        public int Id { get; set; }

        [Display(Name = "Марка")]
        public string Name { get; set; }
    }
}

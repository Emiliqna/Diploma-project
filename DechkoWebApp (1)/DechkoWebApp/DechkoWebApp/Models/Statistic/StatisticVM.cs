using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DechkoWebApp.Models.Statistic
{
    public class StatisticVM
    {
        public int Id { get; set; }

        [Display(Name = "Брой клиенти")]
        public int CountClients { get; set; }

        [Display(Name = "Брой продукти")]
        public int CountProducts { get; set; }

        [Display(Name = "Брой поръчки")]
        public int CountOrders { get; set; }

        [Display(Name = "Общ брой поръчки")]
        public decimal SumOrders { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DechkoWebApp.Abstraction
{
   public interface IStatisticService
    {
        public int CountProducts();
        public int CountClients();
        public int CountOrders();
        public decimal SumOrders();
    }
}

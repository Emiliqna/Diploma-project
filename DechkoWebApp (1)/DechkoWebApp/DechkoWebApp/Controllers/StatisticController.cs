
using DechkoWebApp.Core.Abstraction;
using DechkoWebApp.Models.Statistic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DechkoWebApp.Controllers
{
    [Authorize(Roles = "Administrator")]

    public class StatisticController : Controller
    {
        private readonly IStatisticService statisticService;

        public StatisticController(IStatisticService statisticService)
        {
            this.statisticService = statisticService;
        }

        public ActionResult Index()
        {
            StatisticVM statistic = new StatisticVM();

            statistic.CountClients = statisticService.CountClients();
            statistic.CountProducts = statisticService.CountProducts();
            statistic.CountOrders = statisticService.CountOrders();
            statistic.SumOrders = statisticService.SumOrders();

            return View(statistic);
        }
    }
}

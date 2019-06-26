using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Jasarsoft.AmadeusDev.Repo.DTO;
using Jasarsoft.AmadeusDev.Repo.Helper;
using Jasarsoft.AmadeusDev.Service.IService;
using Jasarsoft.AmadeusDev.Web.Models;
using Jasarsoft.AmadeusDev.Web.Helper;

namespace Jasarsoft.AmadeusDev.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISuccessService successService;
        private readonly IFlightOffersService flightOffersService;

        public HomeController(IFlightOffersService flightOffersService, ISuccessService successService)
        {
            this.successService = successService;
            this.flightOffersService = flightOffersService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public DataTable<FlightDTO> GetFlights(DataTableOptions pagination)
        {
            if (pagination.Columns[1].Search.Value != null)
            {
                //var result = successService.ResponseFromServer(pagination.Columns[1].Search.Value, 15);
                //successService.InsertAsync(result);

                var result = flightOffersService.ResponseFromServer("a", "A");
                flightOffersService.InsertFlight(result);
            }
            

            var totalRecords = flightOffersService.GetNumberOfFlights();

            return new DataTable<FlightDTO>
            {
                Draw = pagination.Draw,
                RecordsTotal = totalRecords,
                RecordsFiltered = totalRecords,
                Data = flightOffersService.GetFlights(pagination.Start,
                                                      pagination.Length,
                                                      pagination.Order[0].Dir,
                                                      pagination.Columns[pagination.Order[0].Column].Name,
                                                      pagination.Columns[1].Search.Value,
                                                      pagination.Columns[2].Search.Value,
                                                      pagination.Columns[2].Search.Value)
            };
        }
    }
}

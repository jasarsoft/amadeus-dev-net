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
        //private readonly ISuccessService successService;
        private readonly IFlightService flightService;

        public HomeController(IFlightService flightOffersService/*, ISuccessService successService*/)
        {
            //this.successService = successService;
            this.flightService = flightOffersService;
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
            var origin = pagination.Columns[1].Search.Value;
            var destination = pagination.Columns[2].Search.Value;
            var departureDate = pagination.Columns[4].Search.Value;
                      
            if (String.IsNullOrEmpty(origin) || String.IsNullOrEmpty(destination) || String.IsNullOrEmpty(departureDate))
            {
                return new DataTable<FlightDTO>
                {
                    Draw = pagination.Draw,
                    RecordsTotal = 0,
                    RecordsFiltered = 0,
                    Data = new List<FlightDTO>()
                };
            }

            origin = origin.ToUpper();
            destination = destination.ToUpper();

            var returnDate = pagination.Columns[5].Search.Value;
            var currency = (pagination.Columns[3].Search.Value ?? Default.CURRENCY).ToUpper();
            var adults = Convert.ToInt32(pagination.Columns[6].Search.Value ?? Default.ADULTS.ToString());

            var totalRecords = flightService.GetNumberOfFlights(origin, destination, departureDate, returnDate, currency, adults);

            return new DataTable<FlightDTO>
            {
                Draw = pagination.Draw,
                RecordsTotal = totalRecords,
                RecordsFiltered = totalRecords,
                Data = flightService.GetFlights(pagination.Start,
                                                      pagination.Length,
                                                      pagination.Order[0].Dir,
                                                      pagination.Columns[pagination.Order[0].Column].Name,
                                                      origin, destination, departureDate, returnDate, currency, adults)
            };
        }

        [HttpPost]
        public DataTable<FlightDTO> GetFlightsTuple(DataTableOptions pagination)
        {
            var origin = pagination.Columns[1].Search.Value;
            var destination = pagination.Columns[2].Search.Value;
            var departureDate = pagination.Columns[4].Search.Value;

            if (String.IsNullOrEmpty(origin) || String.IsNullOrEmpty(destination) || String.IsNullOrEmpty(departureDate))
            {
                return new DataTable<FlightDTO>
                {
                    Draw = pagination.Draw,
                    RecordsTotal = 0,
                    RecordsFiltered = 0,
                    Data = new List<FlightDTO>()
                };
            }

            origin = origin.ToUpper();
            destination = destination.ToUpper();

            var returnDate = pagination.Columns[5].Search.Value;
            var currency = (pagination.Columns[3].Search.Value ?? Default.CURRENCY).ToUpper();
            var adults = Convert.ToInt32(pagination.Columns[6].Search.Value ?? Default.ADULTS.ToString());

            var totalRecords = flightService.GetNumberOfFlights(origin, destination, departureDate, returnDate, currency, adults);

            var flightTuple = flightService.GetFlightsTuple(pagination.Start,
                pagination.Length,
                pagination.Order[0].Dir,
                pagination.Columns[pagination.Order[0].Column].Name,
                origin, destination, departureDate, returnDate, currency, adults);

            return new DataTable<FlightDTO>
            {
                Draw = pagination.Draw,
                Data = flightTuple.Item2,
                RecordsFiltered = flightTuple.Item1,
                RecordsTotal = flightTuple.Item1,
            };
        }

        [HttpPost]
        public async Task<DataTable<FlightDTO>> GetFlightsAsync(DataTableOptions pagination)
        {
            var origin = pagination.Columns[1].Search.Value;
            var destination = pagination.Columns[2].Search.Value;
            var departureDate = pagination.Columns[4].Search.Value;

            if (String.IsNullOrEmpty(origin) || String.IsNullOrEmpty(destination) || String.IsNullOrEmpty(departureDate))
            {
                return new DataTable<FlightDTO>
                {
                    Draw = pagination.Draw,
                    RecordsTotal = 0,
                    RecordsFiltered = 0,
                    Data = new List<FlightDTO>()
                };
            }

            origin = origin.ToUpper();
            destination = destination.ToUpper();

            var returnDate = pagination.Columns[5].Search.Value;
            var currency = (pagination.Columns[3].Search.Value ?? Default.CURRENCY).ToUpper();
            var adults = Convert.ToInt32(pagination.Columns[6].Search.Value ?? Default.ADULTS.ToString());

            var totalRecords = await flightService.GetNumberOfFlightsAsync(origin, destination, departureDate, returnDate, currency, adults);

            return new DataTable<FlightDTO>
            {
                Draw = pagination.Draw,
                RecordsTotal = totalRecords,
                RecordsFiltered = totalRecords,
                Data = await flightService.GetFlightsAsync(pagination.Start,
                                                      pagination.Length,
                                                      pagination.Order[0].Dir,
                                                      pagination.Columns[pagination.Order[0].Column].Name,
                                                      origin, destination, departureDate, returnDate, currency, adults)
            };
        }
    }
}

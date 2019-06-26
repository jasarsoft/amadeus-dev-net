using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jasarsoft.AmadeusDev.Repo.Models.Flights
{
    [Table("PricingDetail", Schema = "Flights")]
    public class PricingDetail
    {
        [Key]
        public int PricingDetailId { get; set; }

        public string TravelClass { get; set; } //quality of service offered in the cabin where the seat is located in this flight.Economy, premium economy, business or first class = ['ECONOMY', 'PREMIUM_ECONOMY', 'BUSINESS', 'FIRST']
        public string FareClass { get; set; } //class of the fare that applied.Fare classes are subdivisions of travel classes and vary from airline to airline. For instance, Y designs usually a full fare economy class
        public int? Availability { get; set; } //the number of seats still available at this time of search with this class of fare
        public string FareBasis { get; set; } //the identifier of the fare that applied.Farebasis identifiers vary from airline to airline.It is usually composed of the fare class followed by other alphanumeric codes that identify the rules that apply to the fare.For instance, WH7LNR might mean that the fare class is W, that it is valid during high-season only(H) and for a 7-day advance purchase, long-haul(L) and not refundable(NR)
    }
}

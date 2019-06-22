using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jasarsoft.AmadeusDev.Data.Entities
{
    public class FlightSegment
    {
        //departure(FlightEndPoint, optional),
        //arrival(FlightEndPoint, optional),
        //carrierCode(string, optional) : providing the airline / carrier code,
        //number (string, optional): the flight number as assigned by the carrier,
        //aircraft (AircraftEquipment, optional),
        //operating (OperatingFlight, optional),
        //duration (string, optional): stop duration in ISO8601 PnYnMnDTnHnMnS format, e.g.PT2H10M ,
        //stops(Array[FlightStop], optional) : information regarding the different stops composing the flight segment.E.g.technical stop, change of gauge...
        public FlightEndPoint departure { get; set; }
        public FlightEndPoint arrival { get; set; }
        public string carrierCode { get; set; }
        public string number { get; set; }
        public AircraftEquipment aircraft { get; set; }
        public OperatingFlight operating { get; set; }
        public string duration { get; set; }
        public List<FlightStop> stops { get; set; }
    }
}

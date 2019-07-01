using System;
using System.Collections.Generic;
using System.Text;

namespace Jasarsoft.AmadeusDev.Repo.DTO
{
    public class FlightDTO
    {
        public string Departure { get; set; } //polazni aerodrom 
        public string Arrival { get; set; } // odredišni aerodrom 
        public string DepartureTime { get; set; } // datum polaska
        public string ArrivalTime { get; set; } // datum povratka
        public int DepartureTransfer { get; set; }// broj presjedanja u odlaznom putovanju 
        public int ArrivalTransfer { get; set; } // broj presjedanja u povratnom putovanju 
        public int Passanger { get; set; } // broj putnika 
        public string Currency { get; set; } // valuta
        public string Price { get; set; } // ukupna cijena 
    }
}

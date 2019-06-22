using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jasarsoft.AmadeusDev.Data.Entities
{
    public class AircraftEquipment
    {
        //code (string, optional): IATA aircraft code (http://www.flugzeuginfo.net/table_accodes_iata_en.php)
        public string code { get; set; }
    }
}

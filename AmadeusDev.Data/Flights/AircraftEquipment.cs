using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jasarsoft.AmadeusDev.Data.Flights
{
    [Table("AircraftEquipment", Schema = "Flights")]
    public class AircraftEquipment
    {        
        [Key]
        public int AircraftEquipmentId { get; set; }

        public string Code { get; set; } //IATA aircraft code (http://www.flugzeuginfo.net/table_accodes_iata_en.php)
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jasarsoft.AmadeusDev.Data.Entities
{
    public class Defaults
    {
        //nonStop(boolean, optional) : search finds only direct flights going from the origin to the destination with no stop ,
        //adults(integer, optional) : search does the computation for one adult
        public bool nonStop { get; set; }
        public int adults { get; set; }
    }
}

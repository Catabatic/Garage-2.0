using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage20.Models
{
    public class ParkedVehicle
    {
        public enum Type
        {
            Car,
            Motorcycle,
            Boat,
            Airplane,
        }

        public string RegNr { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int WheelsAmount { get; set; }
    }
}
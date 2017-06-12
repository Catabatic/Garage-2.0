using Garage20.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Garage20.Models
{
    public class ParkedVehicle
    {
        public int Id { get; set; }
        public string RegNr { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int WheelsAmount { get; set; }
        public VehicleType VehicleType { get; set; }
    }

    
}
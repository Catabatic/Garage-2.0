using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage20.Models
{
    public class VehiclesMembers
    {
        public int Id { get; set; }
        public Vehicles Vehicle { get; set; }
        public Members Member { get; set; }
    }
}
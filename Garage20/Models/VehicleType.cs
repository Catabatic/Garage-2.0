using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Garage20.Models
{
    public class VehicleType
    {
        public int Id { get; set; }
        [DisplayName("Fordonstyp")]
        public string VehicleTypeName { get; set; }

        

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Garage20.DataAccess
{
    public class GarageContext:DbContext
    {
        public GarageContext():base("DefaultConnection")
        {

        }
        public DbSet<Models.ParkedVehicle> ParkedVehicles { get; set; }
    }
}
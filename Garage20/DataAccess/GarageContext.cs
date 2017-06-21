using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;//added to use DbContext

namespace Garage20.DataAccess
{
    public class GarageContext:DbContext //Db Context permits to use the dtatbase
    {
        public GarageContext():base("Garage2.5") //Name of the database
        {

        }

        public DbSet<Models.ParkedVehicle> ParkedVehicles { get; set; }
        public DbSet<Models.Members> Members { get; set; }
        public DbSet<Models.Vehicles> Vehicles { get; set; }
        public DbSet<Models.VehicleType> VehicleType { get; set; }

    }
}
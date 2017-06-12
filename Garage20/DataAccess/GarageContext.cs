using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;//added to use DbContext

namespace Garage20.DataAccess
{
    public class GarageContext:DbContext //Db Context permits to use the dtatbase
    {
        public GarageContext():base("DefaultConnection") //connection for the database?
        {

        }
        public DbSet<Models.ParkedVehicle> ParkedVehicles { get; set; }
    }
}
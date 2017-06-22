using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage20.Models
{

    public class Members
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNbr { get; set; }
        public string Email { get; set; }


        public virtual ICollection<Vehicles> Vehicles { get; set; }
        
    }
}
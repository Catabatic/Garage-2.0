using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage20.Models
{
    public class Vehicles
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int VehicleTypeId { get; set; }

        public string Verification { get; set; }
        
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "Only letters and numbers are allowed")]
        [DisplayName("Registreringsnummer")]
        public string RegNr { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-ZåäöÅÄÖ]*$", ErrorMessage = "Only letters are allowed")]
        [DisplayName("Färg")]
        public string Color { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-ZåäöÅÄÖ]*$", ErrorMessage = "Only letters are allowed")]
        [DisplayName("Märke")]
        public string Brand { get; set; }
        [Required]
        [DisplayName("Modell")]
        public string Model { get; set; }

        [Required(ErrorMessage = "The Wheels field is required. Write '0' if your vehicle does not have any wheels")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Requires a valid number")]
        [DisplayName("Antal hjul")]
        public int WheelsAmount { get; set; }
        [DisplayName("Inchecknings tid")]
        public DateTime? CheckInTime { get; set; }
        [DisplayName("Utchecknings tid")]
        public DateTime? CheckOutTime { get; set; }
        [DisplayName("Summa att betala")]
        public int AmountFee { get; set; }

        public virtual Members Member { get; set; }
        public virtual VehicleType VehicleType { get; set; }

        public enum VehiculeTypeEnum
        {
            Bil,
            Motorcykel,
            Lastbil,
            Fyrhjuling,
        }


    }
}
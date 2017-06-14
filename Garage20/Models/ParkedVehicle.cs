
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Garage20.Models
{
    public class ParkedVehicle 
    {
        public int Id { get; set; }
        public string Verification { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "Only letters and numbers are allowed")]
        public string RegNr { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Only letters are allowed")]
        public string Color { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Only letters are allowed")]
        public string Brand { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "Only letters and numbers are allowed")]
        public string Model { get; set; }

        [Required(ErrorMessage = "The Wheels field is required. Write '0' if your vehicle does not have any wheels")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Requires a valid number")]
        public int WheelsAmount { get; set; }
        public VehicleType VehicleType { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public int AmountFee { get; set; }
        /*Changed AmountFee to get the ParkedVehicle parking duration and the ticket cost. The ticket cost is right now 5 crowns per 10 minute. (Linus)*/
    }
    public enum VehicleType
    {
        Car,
        Motorcycle,
        Boat,
        Airplane,
    }

}
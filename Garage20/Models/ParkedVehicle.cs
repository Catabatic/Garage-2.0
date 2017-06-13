
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
       // [RegularExpression(@"^[A-Z]+[A-Z]+[A-Z]+[0-9]+[0-9]+[0-9]*$")]
        public string RegNr { get; set; }
       // [RegularExpression(@"^[A-Z]|[a-zA-Z''-'\s]*$")]
        public string Color { get; set; }
       // [RegularExpression(@"^[A-Z]|[a-zA-Z''-'\s]*$")]
        public string Brand { get; set; }
        public string Model { get; set; }
        
        public int WheelsAmount { get; set; }
        public VehicleType VehicleType { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }

        /*Changed AmountFee to get the ParkedVehicle parking duration and the ticket cost. The ticket cost is right now 5 crowns per 10 minute. (Linus)*/
        public TimeSpan? ParkingDuration => CheckOutTime - CheckInTime;
        public int AmountFee => 5 * (int)Math.Ceiling(ParkingDuration?.TotalMinutes / 10 ?? 0);
    }
    public enum VehicleType
    {
        Car,
        Motorcycle,
        Boat,
        Airplane,
    }

}
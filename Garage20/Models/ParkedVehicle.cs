
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
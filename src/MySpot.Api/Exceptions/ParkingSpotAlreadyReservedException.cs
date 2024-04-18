using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySpot.Api.Exceptions
{
    public class ParkingSpotAlreadyReservedException : CustomException
    {
        public DateTime Date { get; }
        public string Name { get; }

        public ParkingSpotAlreadyReservedException(string name, DateTime date)
            : base($"Parking spot: {name} is already reserved at: {date:d}.")
        {
            Name = name;
            Date = date;
        }
    }
}

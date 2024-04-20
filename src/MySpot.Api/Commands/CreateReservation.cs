using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySpot.Api.ValueObjects;

namespace MySpot.Api.Commands;

public record CreateReservation(
    Guid ParkingSpotId,
    Guid ReservationId,
    DateTime Date,
    string EmployeeName,
    LicensePlate LicensePlate
);

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySpot.Api.ValueObjects;

namespace MySpot.Api.Commands;

public record CreateReservation(
    ParkingSpotId ParkingSpotId,
    ReservationId ReservationId,
    Date Date,
    EmployeeName EmployeeName,
    LicensePlate LicensePlate
);

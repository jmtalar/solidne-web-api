using MySpot.Api.ValueObjects;

namespace MySpot.Api.Commands;

public record ChangeReservationLicensePlate(ReservationId ReservationId, string LicensePlate);

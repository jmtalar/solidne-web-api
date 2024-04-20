using MySpot.Api.ValueObjects;

namespace MySpot.Api.Commands;

public record ChangeReservationLicensePlate(Guid ReservationId, LicensePlate LicensePlate);

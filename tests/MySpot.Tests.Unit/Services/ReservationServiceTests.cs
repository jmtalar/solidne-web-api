using MySpot.Api.Commands;
using MySpot.Api.Services;
using MySpot.Api.ValueObjects;
using Shouldly;

namespace MySpot.Tests.Unit.Services;

public class ReservationServiceTests
{

    [Fact]
    public void given_reservation_for_not_taken_date_create_reservation_should_succeed( )
    {
        var command = new CreateReservation(Guid.Parse("00000000-0000-0000-0000-000000000001"), Guid.NewGuid(), new Date(DateTime.UtcNow.AddMinutes(5)), "John Doe", "XYZ123");
        var _reservationId = _reservationsService.Create(command);

        _reservationId.ShouldNotBeNull();
        _reservationId.Value.ShouldBe<Guid>(command.ReservationId);
    }
    
    #region Arrange

    private readonly ReservationsService _reservationsService;

    public ReservationServiceTests()
    {
        _reservationsService = new ReservationsService();
    }
    
    #endregion
}
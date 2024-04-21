using MySpot.Api.Entities;
using MySpot.Api.Exceptions;
using MySpot.Api.ValueObjects;
using Shouldly;

namespace MySpot.Tests.Unit.Entities;

public class WeeklyParkingSpotTests
{
    [Theory]
    [InlineData("2024-04-03")]
    [InlineData("2024-04-28")]
    public void given_invalid_date_add_reservation_should_fail(string dateString)
    {
        // ARRANGE 
        var invalidDate = DateTime.Parse(dateString);
        var reservation = new Reservation(Guid.NewGuid(), _weeklyParkingSpot.Id, "John Doe", "XYZ123", new Date(invalidDate));
        
        // ACT
        var exception = Record.Exception(() => _weeklyParkingSpot.AddReservation(reservation, _now));

        // ASSERT 
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<InvalidReservationDateException>();
    }
    
    [Fact]
    public void given_reservation_for_already_existing_date_add_reservation_should_fail()
    {
        // ARRANGE 
        var reservationDate = _now.AddDays(1);
        var reservation = new Reservation(Guid.NewGuid(), _weeklyParkingSpot.Id, "John Doe", "XYZ123", reservationDate);
        var nextReservation = new Reservation(Guid.NewGuid(), _weeklyParkingSpot.Id, "John Doe", "XYZ123", reservationDate);

        _weeklyParkingSpot.AddReservation(reservation, _now);
        
        // ACT
        var exception = Record.Exception( () => _weeklyParkingSpot.AddReservation(nextReservation, _now));
            
    
        // ASSERT 
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<ParkingSpotAlreadyReservedException>();
    }

    private readonly WeeklyParkingSpot _weeklyParkingSpot;
    private readonly Date _now;

    public WeeklyParkingSpotTests()
    {
        _now = new Date(new DateTime(2024, 04, 5));
        _weeklyParkingSpot = new WeeklyParkingSpot(Guid.NewGuid(), new Week(_now), "P1");
    }
    
}
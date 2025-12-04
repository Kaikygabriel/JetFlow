using JwtFlow.Domain.BackOffice.ObjectValue;

namespace JwtFlow.Products.Test.Domain.BackOffice.ObjectValue;

public class FlightCityTest
{
    private const string CITYSTART_VALID = "São Paulo";
    private const string? CITYSTART_NULL = null;
    
    private const string CITYOUT_VALID = "Rio de janeiro";
    private const string? CITYOUT_NULL = null;
    private const string CITYOUT_EQUAL_CITYSTART_VALID = "São Paulo";

    [Fact]
    public void CreateFlightCity_With_CityStartNull_CityOutNull_Return_Exception()
    {
        Assert.Throws<Exception>(()
            => new FlightCity(CITYSTART_NULL, CITYOUT_NULL));
    }
    
    [Fact]
    public void CreateFlightCity_With_CityOutEqualsCityStart_Return_Exception()
    {
        Assert.Throws<Exception>(()
            => new FlightCity(CITYSTART_VALID, CITYOUT_EQUAL_CITYSTART_VALID));
    }
    
    [Fact]
    public void CreateFlightCity_With_CityStartValid_CityOutValid_Return_NotNull()
    {
        var flight = new FlightCity(CITYSTART_VALID, CITYOUT_VALID);
        Assert.NotNull(flight);
    }
}
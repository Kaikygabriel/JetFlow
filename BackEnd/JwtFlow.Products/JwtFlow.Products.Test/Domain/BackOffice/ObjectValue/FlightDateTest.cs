using JwtFlow.Domain.BackOffice.Exceptions;
using JwtFlow.Domain.BackOffice.ObjectValue;

namespace JwtFlow.Products.Test.Domain.BackOffice.ObjectValue;

public class FlightDateTest
{
    private readonly DateTime DATE_START_INVALID = new DateTime(2000,1,3);
    private readonly DateTime DATE_START_VALID = DateTime.Now.AddDays(2);
    
    private readonly DateTime DATE_OUT_INVALID = new DateTime(2000,1,2);
    private readonly DateTime DATE_OUT_VALID = DateTime.Now.AddDays(3);
    private readonly DateTime DATE_OUT_EARLIER = new DateTime(2000,1,2);
        
    [Fact]
    public void CreateFlightDate_With_DateStartInvalid_DateOutInvalid_Return_Exception()
    {
        Assert.Throws<FlightDateException>(()
            => new FlightDate(DATE_START_INVALID,DATE_OUT_INVALID));
    }
    [Fact]
    public void CreateFlightDate_With_DateOut_Earlier_That_DateStart_Return_Exception()
    {
        Assert.Throws<FlightDateException>(()
            => new FlightDate(DATE_START_VALID,DATE_OUT_EARLIER));
    }
    [Fact]
    public void CreateFlightDate_With_DateStartValid_DateOutValid_Return_NotNull()
    {
        var date  = new FlightDate(DATE_START_VALID,DATE_OUT_VALID);
        Assert.NotNull(date);
    }
}
using JwtFlow.Domain.BackOffice.Entities;
using JwtFlow.Domain.BackOffice.Exceptions;
using JwtFlow.Domain.BackOffice.ObjectValue;

namespace JwtFlow.Products.Test.Domain.BackOffice.Entities;

public class ProductFlightTest
{
    private const decimal PRICE_VALID = 101.11M;
    private const decimal PRICE_INVALID = -10M;
    
    private const string NAME_VALID = "AA11";
    private const string NAME_INVALID = "";
    
    private readonly FlightDate FlightDate_Valid = new(DateTime.Now.AddHours(10),DateTime.Now.AddDays(10));
    private readonly FlightCity FlightCity_Valid = new("Rio de janeiro", " São paulo");
    
    [Fact]
    public void CreateProductFlight_with_NameInvalid_PriceInvalid_Return_FlightException()
    {
        Assert.Throws<FlightException>(()
            => new ProductFlight(FlightDate_Valid, FlightCity_Valid, PRICE_INVALID, NAME_INVALID));
    }
    
    [Fact]
    public void CreateProductFlight_with_NameValid_PriceValid_Return_NotNull()
    {
        var model = new ProductFlight(FlightDate_Valid, FlightCity_Valid, PRICE_VALID, NAME_VALID);
        Assert.NotNull(model);
    }
}
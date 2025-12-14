using JwtFlow.Application.UseCases.Flight.Command.Create;
using JwtFlow.Application.UseCases.Flight.Command.Update;
using JwtFlow.Domain.BackOffice.Entities;
using JwtFlow.Domain.BackOffice.ObjectValue;
using JwtFlow.Products.Test.Mock;

namespace JwtFlow.Products.Test.Application.UseCases.Flight.Command;

public class UpdateTest
{
    private readonly UpdateHandler _handler = new( new FakeUnitOfWork());
    
    [Fact]
    public async Task Should_Return_False_If_IdPassed_IsNotEquals_FlightId()
    {
        var id = Guid.NewGuid();
        var flight = new ProductFlight
        (new(DateTime.Now.AddDays(1), DateTime.Now.AddDays(2)),
            new FlightCity("testes", "testes"),
            1313,"teste"){Id = Guid.NewGuid()};
        var result = await _handler.HandleAsync(new(flight,id));
        Assert.False(result);
    }
    [Fact]
    public async Task Should_Return_true_If_IdOk_And_FlightOk()
    {
        var id = Guid.NewGuid();
        var flight = new ProductFlight
        (new(DateTime.Now.AddDays(1), DateTime.Now.AddDays(2)),
            new FlightCity("testes", "testes"),
            1313,"teste"){Id = id};
        var result = await _handler.HandleAsync(new(flight,id));
        Assert.True(result);
    }
}
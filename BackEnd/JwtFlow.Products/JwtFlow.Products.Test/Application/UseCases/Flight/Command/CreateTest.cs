using JwtFlow.Application.UseCases.Flight.Command.Create;
using JwtFlow.Domain.BackOffice.Entities;
using JwtFlow.Domain.BackOffice.ObjectValue;
using JwtFlow.Products.Test.Mock;

namespace JwtFlow.Products.Test.Application.UseCases.Flight.Command;

public class CreateTest
{
    private readonly CreateHandler _handler = new( new FakeUnitOfWork());
    
    [Fact]
    public async  Task Create_Should_If_FlightExisting_Return_False()
    {
        var flightExisting = new ProductFlight(
            new FlightDate(DateTime.Now.AddDays(2), DateTime.Now.AddDays(5)),
            new FlightCity("São Paulo", "Rio de Janeiro"),
            899,
            "Viagem SP → RJ"
        ){
            Id =Guid.Parse("8f3d3f2c-9c42-4c34-a2f2-3e9bb0b8e7f1")
        };
        var command = new CreateCommand(flightExisting);

        var result = await _handler.HandleAsync(command);
        
        Assert.False(result);
    }
    
    [Fact]
    public async Task Create_Should_If_FlightNull_Return_False()
    {
        var command = new CreateCommand(null);

        var result = await _handler.HandleAsync(command);
        
        Assert.False(result);
    }
    
    [Fact]
    public async Task Create_Should_If_FlightOk_Return_True()
    {
        var flight = new ProductFlight(
            new FlightDate(DateTime.Now.AddDays(4), DateTime.Now.AddDays(50)),
            new FlightCity("teste", "teste2"),
            700,
            "testeteste"
        )
        {
            Id = Guid.NewGuid()
        };
        var command = new CreateCommand(flight);

        var result = await _handler.HandleAsync(command);
        
        Assert.True(result);    
    }
}
using JwtFlow.Application.UseCases.Flight.Command.Delete;
using JwtFlow.Products.Test.Mock;

namespace JwtFlow.Products.Test.Application.UseCases.Flight.Command;

public class DeleteTest
{
    private readonly DeleteHandler _handler = new DeleteHandler(new FakeUnitOfWork());
    
    private const string ID_VALID = "8f3d3f2c-9c42-4c34-a2f2-3e9bb0b8e7f1";
    private const string ID_INVALID = "djkfalsdjlkalfdçajksdçfjaldfasdfj";
    
    [Fact]
    public async Task Should_Return_False_If_ProductFlightNoExisting()
    {
        var command = new DeleteCommand(ID_INVALID);
        var result = await _handler.HandleAsync(command);
        Assert.False(result);
    }
    
    [Fact]
    public async Task Should_Return_True_If_ProductFlightExisting()
    {
        var command = new DeleteCommand(ID_VALID);
        var result = await _handler.HandleAsync(command);
        Assert.True(result);
    }
}
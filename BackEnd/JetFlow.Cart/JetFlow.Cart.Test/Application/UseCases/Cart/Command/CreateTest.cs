using JetFlow.Cart.Application.UseCases.Cart.Command.Create;
using JetFlow.Cart.Test.Mocks;

namespace JetFlow.Cart.Test.Application.UseCases.Cart.Command;

public class CreateTest
{
    private CreateCartHandler _handler = new CreateCartHandler(new FakeUnitOfWork());
    
    private readonly JetFlow.Cart.Domain.BackOffice.Entities.Cart CART_VALID = new(10);
    private readonly JetFlow.Cart.Domain.BackOffice.Entities.Cart CART_EXISTING = new(1);
    private readonly JetFlow.Cart.Domain.BackOffice.Entities.Cart? CART_NULL = null;

    [Fact]
    public async Task Should_Return_false_If_CartIsNull()
    {
        var command = new CreateCartCommand(CART_NULL);
        var result = await _handler.HandleAsync(command); 
        Assert.False(result);
    }
    
    [Fact]
    public async Task Should_Return_false_If_CartExisting()
    {
        var command = new CreateCartCommand(CART_EXISTING);
        var result = await _handler.HandleAsync(command); 
        Assert.False(result);
    }
    
    [Fact]
    public async Task Should_Return_True_If_CartIsValid()
    {
        var command = new CreateCartCommand(CART_VALID);
        var result = await _handler.HandleAsync(command); 
        Assert.True(result);
    }
}
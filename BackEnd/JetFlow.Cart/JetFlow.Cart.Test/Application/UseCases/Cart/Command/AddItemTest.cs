using JetFlow.Cart.Application.UseCases.Cart.Command.AddITem;
using JetFlow.Cart.Domain.BackOffice.ObjectValue;
using JetFlow.Cart.Test.Mocks;

namespace JetFlow.Cart.Test.Application.UseCases.Cart.Command;

public class AddItemTest
{
    private readonly AddItemHandler _handler = new(new FakeUnitOfWork());
    private readonly CartItem CartItem_IdUserInvalid = new(USERID_INVALID,2,"teste","testes description","teste.url",10,2,1);
    private readonly CartItem CartItem_Valid = new(USERID_VALID,2,"teste","testes description","teste.url",10,2,1);
    private const int USERID_INVALID = 101;
    private const int USERID_VALID = 1;
    [Fact]
    public async Task Should_Return_false_If_CartNoExisting()
    {
        //arrange
        var command = new AddItemCommand(USERID_INVALID, CartItem_Valid);
        //act
        var result = await _handler.HandleAsync(command);
        //assert
        Assert.False(result);
    }
    [Fact]
    public async Task Should_Return_True_If_CartExisting()
    {
        //arrange
        var command = new AddItemCommand(USERID_VALID, CartItem_Valid);
        //act
        var result = await _handler.HandleAsync(command);
        //assert
        Assert.True(result);
    }
    [Fact]
    public async Task Should_Return_False_If_CartUserId_IsNotEquals_ItemUserId()
    {
        //arrange
        var command = new AddItemCommand(USERID_VALID, CartItem_IdUserInvalid);
        //act
        var result = await _handler.HandleAsync(command);
        //assert
        Assert.False(result);
    }
}
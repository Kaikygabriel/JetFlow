using JetFlow.Cart.Application.UseCases.Cart.Command.DeleteItem;
using JetFlow.Cart.Test.Mocks;

namespace JetFlow.Cart.Test.Application.UseCases.Cart.Command;

public class DeleteItemTest
{
  private readonly DeleteItemHandler _handler = new (new FakeUnitOfWork());

  private const int IDCART_VALID = 3;
  private const int IDCART_INVALID = 12;
  
  private const int USERID_VALID = 2;
  private const int USERID_INVALID = 12;

  [Fact]
  public async Task Should_Return_False_If_IdCartNoExisting()
  {
    DeleteItemCommand command = new(IDCART_INVALID, USERID_VALID);
    bool result = await _handler.HandleAsync(command);
    Assert.False(result);
  } 
  [Fact]
  public async Task Should_Return_False_If_UserIdCartItem_IsNotEquals_UserId()
  {
    DeleteItemCommand command = new(IDCART_VALID, USERID_INVALID);
    bool result = await _handler.HandleAsync(command);
    Assert.False(result);
  } 
  [Fact]
  public async Task Should_Return_true_If_IdCartIsValid_And_UserIdIsValid()
  {
    DeleteItemCommand command = new(IDCART_VALID,USERID_VALID);
    bool result = await _handler.HandleAsync(command);
    Assert.True(result);
  } 
}
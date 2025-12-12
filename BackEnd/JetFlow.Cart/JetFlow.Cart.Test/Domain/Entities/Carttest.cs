using JetFlow.Cart.Domain.BackOffice.Exceptions;

namespace JetFlow.Cart.Test.Domain.Entities;

public class Carttest
{
    private const int USERID_VALID = 1;
    private const int USERID_INVALID = -1;

    [Fact]
    public void Should_Return_Exception_If_UserIdInvalid()
    {
        Assert.Throws<CartException>(()
            => new Cart.Domain.BackOffice.Entities.Cart(USERID_INVALID));
    }
    [Fact]
    public void Should_Return_NotNull_If_UserIdValid()
    {
        var cart = new Cart.Domain.BackOffice.Entities.Cart(USERID_VALID);
        Assert.NotNull(cart);
    }
    
}
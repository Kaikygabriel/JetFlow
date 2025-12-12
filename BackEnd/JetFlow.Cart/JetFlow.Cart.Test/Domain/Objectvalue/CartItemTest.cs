using JetFlow.Cart.Domain.BackOffice.Exceptions;
using JetFlow.Cart.Domain.BackOffice.ObjectValue;

namespace JetFlow.Cart.Test.Domain.Objectvalue;

public class CartItemTest
{
    [Fact]
    public void Should_Return_CartItemException_If_ParameternsOfContructorInvalid()
    {
        Assert.Throws<CartItemException>(() => 
        new CartItem(1,1,string.Empty,string.Empty,string.Empty,-1,-1,1));
    }
    [Fact]
    public void Should_Return_NotNull_If_ParameternsOfContructorValid()
    {
       var cart = new CartItem(1,1,"teste","teste","teste",101,1,1);
       Assert.NotNull(cart);
    }
}
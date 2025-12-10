using JetFlow.Cart.Domain.BackOffice.Exceptions;
using JetFlow.Cart.Domain.BackOffice.Entities.Contracts;
using JetFlow.Cart.Domain.BackOffice.ObjectValue;

namespace JetFlow.Cart.Domain.BackOffice.Entities;

public class Cart : Entity
{
    protected Cart()
    {
        
    }
    public Cart(int productId, int userId)
    {
        if (!IdsValid(productId, userId))
            throw new CartException();
        ProductId = productId;
        UserId = userId;
        
        UpdateLastDate();
    }


    public int ProductId { get;private set; }
    public int UserId { get;private set; }
    public DateTime LastDate { get;private set; }
    public List<CartItem>CartItems{ get;private set; } = new ();

    public void AddCartInItems(CartItem item)
        => CartItems.Add(item);
    
    public void UpdateLastDate()
        => LastDate = DateTime.UtcNow;

    public bool IdsValid(int productId,int userId)
    {
        if (productId < 0 || userId < 0)
            return false;
        return true;
    }
}
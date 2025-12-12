using JetFlow.Cart.Domain.BackOffice.Exceptions;
using JetFlow.Cart.Domain.BackOffice.Entities.Contracts;
using JetFlow.Cart.Domain.BackOffice.ObjectValue;

namespace JetFlow.Cart.Domain.BackOffice.Entities;
 
public class Cart : Entity
{
    public Cart()
    {
        
    }
    public Cart( int userId)
    {
        if (!IdsValid(userId))
            throw new CartException();
        UserId = userId;
        
        UpdateLastDate();
    }

    public int UserId { get;private set; }
    public DateTime LastUpdate { get;private set; }
    private List<CartItem> _cartItems = new ();

    public void AddCartInItems(CartItem item)
        => _cartItems.Add(item);

    public IEnumerable<CartItem> GetCartItems()
        => _cartItems;
    
    public void UpdateLastDate()
        => LastUpdate = DateTime.Now;

    public bool IdsValid(int userId)
    {
        if ( userId <= 0)
            return false;
        return true;
    }
}
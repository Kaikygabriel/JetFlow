namespace JetFlow.Cart.Domain.BackOffice.Exceptions;

public class CartItemException : ApplicationException
{
    private const string DEFAULT_MENSSAGE = "Error in CartItem";
    
    public CartItemException(string menssage  = DEFAULT_MENSSAGE) : base (menssage)
    {
        
    }
}
namespace JetFlow.Cart.Domain.BackOffice.Exceptions;

public class CartException : ApplicationException
{
    private const string DEFAULT_MENSSAGE = "Error in cart";
    
    public CartException(string menssage  = DEFAULT_MENSSAGE) : base (menssage)
    {
        
    }
}
using JetFlow.Cart.Domain.BackOffice.Interfaces.Cart;
using JetFlow.Cart.Domain.BackOffice.Interfaces.CartItem;

namespace JetFlow.Cart.Domain.BackOffice.Interfaces;

public interface IUnitOfWork
{
    public IRepositoryCartItem RepositoryCartItem { get; }
    public IRepositoryCart RepositoryCart { get;}

    Task CommitAsync();
}
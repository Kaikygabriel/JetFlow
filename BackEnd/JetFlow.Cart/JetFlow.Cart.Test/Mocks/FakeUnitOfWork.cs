using JetFlow.Cart.Domain.BackOffice.Interfaces;
using JetFlow.Cart.Domain.BackOffice.Interfaces.Cart;
using JetFlow.Cart.Domain.BackOffice.Interfaces.CartItem;

namespace JetFlow.Cart.Test.Mocks;

public class FakeUnitOfWork : IUnitOfWork
{
    public IRepositoryCartItem RepositoryCartItem { get; } = new FakeRepositoryCartItem();
    public IRepositoryCart RepositoryCart { get; } = new FakeRepositoryCart();
    public async Task CommitAsync()
    {
        await Task.Delay(0);
    }
}
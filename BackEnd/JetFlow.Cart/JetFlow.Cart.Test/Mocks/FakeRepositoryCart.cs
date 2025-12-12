using System.Linq.Expressions;
using JetFlow.Cart.Domain.BackOffice.Interfaces.Cart;

namespace JetFlow.Cart.Test.Mocks;

public class FakeRepositoryCart   : IRepositoryCart
{
    private List<Cart.Domain.BackOffice.Entities.Cart> _carts = new()
    {
        new Cart.Domain.BackOffice.Entities.Cart(1),
        new Cart.Domain.BackOffice.Entities.Cart(2)
    };
    public Task<IEnumerable<Cart.Domain.BackOffice.Entities.Cart>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<Cart.Domain.BackOffice.Entities.Cart>>(_carts);
    }

    public Task<Cart.Domain.BackOffice.Entities.Cart> GetByPredicate(Expression<Func<Cart.Domain.BackOffice.Entities.Cart, bool>> predicate)
    {
        return Task.FromResult<Cart.Domain.BackOffice.Entities.Cart>(_carts.AsQueryable().FirstOrDefault(predicate));
    }

    public async Task Create(Cart.Domain.BackOffice.Entities.Cart entity)
    {
        if (entity is null)
            throw new NullReferenceException(nameof(entity));
        await Task.Delay(0);
        _carts.Add(entity);
    }

    public async Task Update(Cart.Domain.BackOffice.Entities.Cart entity)
    {
        if (entity is null)
            throw new NullReferenceException(nameof(entity));
        await Task.Delay(0);
        _carts.Add(entity);
    }

    public async Task Delete(Cart.Domain.BackOffice.Entities.Cart entity)
    {
        if (entity is null)
            throw new NullReferenceException(nameof(entity));
        await Task.Delay(0);
        _carts.Remove(entity);
    }

    public Task<Cart.Domain.BackOffice.Entities.Cart?> GetByUserId(Int32 userId)
    {
        return Task.FromResult<Cart.Domain.BackOffice.Entities.Cart?>
            (_carts.FirstOrDefault(x=>x.UserId == userId));
    }
}
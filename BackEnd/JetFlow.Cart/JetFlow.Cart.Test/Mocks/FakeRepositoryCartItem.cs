using System.Linq.Expressions;
using JetFlow.Cart.Domain.BackOffice.Interfaces.CartItem;
using JetFlow.Cart.Domain.BackOffice.ObjectValue;

namespace JetFlow.Cart.Test.Mocks;

public class FakeRepositoryCartItem : IRepositoryCartItem
{
    private readonly List<CartItem> _items;

    public FakeRepositoryCartItem()
    {
        // Popular com dados fake
        _items = new List<CartItem>
        {
            new CartItem(
                userId: 1,
                cartId: 100,
                name: "Mouse Gamer",
                description: "Mouse RGB com 7200 DPI",
                imageUrl: "https://example.com/mouse.jpg",
                price: 149.90m,
                quantity: 1,
                productId: 10
            ) { Id = 1 },

            new CartItem(
                userId: 1,
                cartId: 100,
                name: "Teclado Mecânico",
                description: "Switch Blue ABNT2",
                imageUrl: "https://example.com/teclado.jpg",
                price: 299.90m,
                quantity: 1,
                productId: 11
            ) { Id = 2 },

            new CartItem(
                userId: 2,
                cartId: 200,
                name: "Headset",
                description: "Headset com microfone ativo",
                imageUrl: "https://example.com/headset.jpg",
                price: 199.90m,
                quantity: 2,
                productId: 12
            ) { Id = 3 }
        };
    }

    public Task<IEnumerable<CartItem>> GetAllAsync()
    {
        return Task.FromResult(_items.AsEnumerable());
    }

    public Task<CartItem> GetById(int id)
    {
        var item = _items.FirstOrDefault(x => x.Id == id);
        return Task.FromResult(item);
    }

    public Task<IEnumerable<CartItem>> GetAllByUserId(int userId)
    {
        var result = _items.Where(x => x.UserId == userId);
        return Task.FromResult(result.AsEnumerable());
    }

    public Task<CartItem> GetByPredicate(Expression<Func<CartItem, bool>> predicate)
    {
        var func = predicate.Compile();
        var item = _items.FirstOrDefault(func);
        return Task.FromResult(item);
    }

    public Task Create(CartItem entity)
    {
        entity.Id = _items.Max(i => i.Id) + 1;
        _items.Add(entity);
        return Task.CompletedTask;
    }

    public Task Update(CartItem entity)
    {
        var existing = _items.FirstOrDefault(x => x.Id == entity.Id);
        if (existing is null)
            return Task.CompletedTask;

        existing.Name = entity.Name;
        existing.Description = entity.Description;
        existing.ImageUrl = entity.ImageUrl;
        existing.Price = entity.Price;
        existing.Quantity = entity.Quantity;
        existing.ProductId = entity.ProductId;
        existing.IdCart = entity.IdCart;
        existing.UserId = entity.UserId;

        return Task.CompletedTask;
    }

    public Task Delete(CartItem entity)
    {
        _items.Remove(entity);
        return Task.CompletedTask;
    }
}

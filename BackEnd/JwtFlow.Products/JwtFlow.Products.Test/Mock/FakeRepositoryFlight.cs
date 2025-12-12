using System.Linq.Expressions;
using JwtFlow.Domain.BackOffice.Entities;
using JwtFlow.Domain.BackOffice.Interface.ProductFlight;
using JwtFlow.Domain.BackOffice.ObjectValue;

namespace JwtFlow.Products.Test.Mock;

public class FakeRepositoryFlight : IRepositoryProductFlight
{
    private readonly List<ProductFlight> _items = new();

    public FakeRepositoryFlight()
    {
        // Populando alguns itens fake
        _items.Add(new ProductFlight(
            new FlightDate(DateTime.Now.AddDays(2), DateTime.Now.AddDays(5)),
            new FlightCity("São Paulo", "Rio de Janeiro"),
            899,
            "Viagem SP → RJ"
        )
        {
            Id =Guid.Parse("8f3d3f2c-9c42-4c34-a2f2-3e9bb0b8e7f1")
        });

        _items.Add(new ProductFlight(
            new FlightDate(DateTime.Now.AddDays(10), DateTime.Now.AddDays(15)),
            new FlightCity("Curitiba", "Salvador"),
            1599,
            "Curitiba → Salvador"
        ));

        _items.Add(new ProductFlight(
            new FlightDate(DateTime.Now.AddDays(20), DateTime.Now.AddDays(25)),
            new FlightCity("Fortaleza", "Manaus"),
            2100,
            "Fortaleza → Manaus"
        ));
    }

    public Task<IEnumerable<ProductFlight>> GetAllAsync(int skip, int take)
    {
        var result = _items.Skip(skip).Take(take);
        return Task.FromResult(result);
    }

    public Task<IEnumerable<ProductFlight>> GetAllByUserAsync(string userId)
    {
        // Como ProductFlight não tem UserId, retornamos tudo
        // Em um caso real, você filtraria pela propriedade
        return Task.FromResult(_items.AsEnumerable());
    }

    public Task<ProductFlight?> GetByPredicate(Expression<Func<ProductFlight, bool>> predicate)
    {
        var compiled = predicate.Compile();
        var result = _items.FirstOrDefault(compiled);
        return Task.FromResult(result);
    }

    public void Create(ProductFlight entity)
    {
        _items.Add(entity);
    }

    public void Update(ProductFlight entity)
    {
        var current = _items.FirstOrDefault(x => x.Id == entity.Id);

        if (current is null)
            return;

        // Atualiza os campos simples
        current.Name = entity.Name;
        current.Price = entity.Price;

        // Atualiza os value objects
        current.FlightCity = entity.FlightCity;
        current.FlightDate = entity.FlightDate;
    }

    public void Delete(ProductFlight entity)
    {
        _items.Remove(entity);
    }
}

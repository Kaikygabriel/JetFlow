using System.Linq.Expressions;
using JwtFlow.Domain.BackOffice.Entities;
using JwtFlow.Domain.BackOffice.Interface.ProductFlight;

namespace JwtFlow.Products.Test.Mock;

public class FakeRepositoryFlight  : IRepositoryProductFlight
{
    public Task<IEnumerable<ProductFlight>> GetAllAsync(int skip, int take)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ProductFlight>> GetAllByUserAsync(string userId)
    {
        throw new NotImplementedException();
    }

    public Task<ProductFlight?> GetByPredicate(Expression<Func<ProductFlight, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public void Create(ProductFlight entity)
    {
        throw new NotImplementedException();
    }

    public void Update(ProductFlight entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(ProductFlight entity)
    {
        throw new NotImplementedException();
    }
}
using System.Linq.Expressions;

namespace JwtFlow.Domain.BackOffice.Interface.ProductFlight;

public interface IRepositoryProductFlight
{
    Task<IEnumerable<Entities.ProductFlight>> GetAllAsync();
    Task<Entities.ProductFlight> GetByPredicate(Expression<Func<Entities.ProductFlight, bool>> predicate);
    void Create(Entities.ProductFlight entity);
    void Update(Entities.ProductFlight entity);
    void Delete(Entities.ProductFlight entity);
}
using System.Linq.Expressions;
using JetFlow.Cart.Domain.BackOffice.Entities.Contracts;

namespace JetFlow.Cart.Domain.BackOffice.Interfaces;

public interface IRepository<T> 
    where T : Entity
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByPredicate(Expression<Func<T, bool>> predicate);
    Task Create(T entity);
    Task Update(T entity);
    Task Delete(T entity);
}
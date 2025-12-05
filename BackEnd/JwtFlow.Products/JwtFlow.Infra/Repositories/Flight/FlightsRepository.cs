using System.Linq.Expressions;
using JwtFlow.Domain.BackOffice.Entities;
using JwtFlow.Domain.BackOffice.Interface.ProductFlight;
using JwtFlow.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace JwtFlow.Infra.Repositories.Flight;

public class FlightsRepository : IRepositoryProductFlight
{
    private readonly AppDbContext context;

    public FlightsRepository(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<ProductFlight>?> GetAllAsync(int skip, int take)
    {
        return await context.Flights.AsNoTracking().Skip(skip).Take(take).ToListAsync();
    }

    public async Task<IEnumerable<ProductFlight>?> GetAllByUserAsync(string userId)
    {
        return await context.Flights.AsQueryable().AsNoTracking().
            Where(x=>x.UsersId.Contains(userId)).ToListAsync();
    }

    public async Task<ProductFlight?> GetByPredicate(Expression<Func<ProductFlight, bool>> predicate)
    {
        return await context.Flights.AsNoTracking().FirstOrDefaultAsync(predicate);
    }

    public void Create(ProductFlight entity)
    {
        if (entity is null)
            throw new ArgumentNullException(nameof(entity));
        context.Flights.Add(entity);
    }

    public void Update(ProductFlight entity)
    {
        if (entity is null)
            throw new ArgumentNullException(nameof(entity));
        context.Flights.Update(entity);
    }

    public void Delete(ProductFlight entity)
    {
        if (entity is null)
            throw new ArgumentNullException(nameof(entity));
        context.Flights.Remove(entity);
    }
}
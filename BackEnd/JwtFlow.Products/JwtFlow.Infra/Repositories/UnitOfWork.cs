using JwtFlow.Domain.BackOffice.Interface;
using JwtFlow.Domain.BackOffice.Interface.ProductFlight;
using JwtFlow.Infra.Data.Context;
using JwtFlow.Infra.Repositories.Flight;

namespace JwtFlow.Infra.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private FlightsRepository _flightsRepository;
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public IRepositoryProductFlight RepositoryProductFlight
    {
        get
        {
            return _flightsRepository = _flightsRepository ?? new(_context);
        }
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
}
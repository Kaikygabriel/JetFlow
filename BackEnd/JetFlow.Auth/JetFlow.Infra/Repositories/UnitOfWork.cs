using JetFlow.Domain.BackOffice.Interfaces;
using JetFlow.Infra.Data.Context;
using JetFlow.Infra.DataDapper;
using Microsoft.Extensions.Configuration;

namespace JetFlow.Infra.Repositories;

public class UnitOfWork  :IUnitOfWork
{
    private IConfiguration _configuration;
    private RepositoryUser _repositoryUser;
    private readonly AppDbContext _context;
    
    public UnitOfWork(AppDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public IRepositoryUser RepositoryUser
    {
        get
        {
            return _repositoryUser = _repositoryUser ?? new RepositoryUser(_context,new DbContextDapper(_configuration));
        }
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
}
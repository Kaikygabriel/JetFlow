using JwtFlow.Domain.BackOffice.Interface.ProductFlight;

namespace JwtFlow.Domain.BackOffice.Interface;

public interface IUnitOfWork
{
    public IRepositoryProductFlight RepositoryProductFlight { get; }

    Task CommitAsync();
}
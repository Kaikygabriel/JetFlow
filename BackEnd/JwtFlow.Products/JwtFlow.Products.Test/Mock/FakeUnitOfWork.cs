using JwtFlow.Domain.BackOffice.Interface;
using JwtFlow.Domain.BackOffice.Interface.ProductFlight;

namespace JwtFlow.Products.Test.Mock;

public class FakeUnitOfWork : IUnitOfWork
{
    public IRepositoryProductFlight RepositoryProductFlight { get; } = new FakeRepositoryFlight();
    public async Task CommitAsync()
    {
        await Task.Delay(0);
    }
}
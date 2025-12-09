using JetFlow.Domain.BackOffice.Interfaces;

namespace JwtFlow.Auth.Test.Mock;

public class FakeUnitOfWork :  IUnitOfWork
{
    public IRepositoryUser RepositoryUser { get; } = new FakeRepositoryUser();
    public async Task CommitAsync()
    {
        await Task.Delay(0);
    }
}
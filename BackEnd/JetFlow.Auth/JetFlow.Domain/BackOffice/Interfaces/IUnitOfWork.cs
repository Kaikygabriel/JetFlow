namespace JetFlow.Domain.BackOffice.Interfaces;

public interface IUnitOfWork
{
    public IRepositoryUser RepositoryUser { get;}

    Task CommitAsync();
}
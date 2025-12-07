using JetFlow.Domain.BackOffice.Entities;

namespace JetFlow.Domain.BackOffice.Interfaces;

public interface IRepositoryUser
{
    Task<User?> GetUserByEmail(string addressEmail);
    void Create(User user);
    void Update(User user);
    void Delete(User user);
}
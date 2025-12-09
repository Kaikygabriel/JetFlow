using JetFlow.Domain.BackOffice.Entities;
using JetFlow.Domain.BackOffice.Interfaces;
using JetFlow.Domain.BackOffice.ObjectValues;

namespace JwtFlow.Auth.Test.Mock;

public class FakeRepositoryUser : IRepositoryUser
{
    private List<User> _users = new List<User>()
    {
        new User("John Admin", new Email("admin@jetflow.com"), 
            BCrypt.Net.BCrypt.HashPassword("admin123"))
        {
            Id = 1
        },
        new User("Jane Doe", new Email("jane.doe@jetflow.com"), 
            BCrypt.Net.BCrypt.HashPassword("admin123"))
        {
            Id = 2
        }
    };
    public Task<User?> GetUserByEmail(string addressEmail)
    {
        return Task.FromResult<User>(
            _users.FirstOrDefault(x => x.Email.Address == addressEmail));
    }

    public void Create(User user)
    {
        if (user is null)
            throw new Exception();
        _users.Add(user);
    }

    public void Update(User user)
    {
        if (user is null)
            throw new Exception();
        _users.Add(user);
    }

    public void Delete(User user)
    {
        if (user is null)
            throw new Exception();
        _users.Remove(user);
    }
}
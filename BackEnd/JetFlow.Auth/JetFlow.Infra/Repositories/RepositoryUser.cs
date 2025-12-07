using JetFlow.Domain.BackOffice.Entities;
using JetFlow.Domain.BackOffice.Interfaces;
using JetFlow.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace JetFlow.Infra.Repositories;

public class RepositoryUser : IRepositoryUser
{
    private readonly AppDbContext _context;

    public RepositoryUser(AppDbContext context)
    {
        _context = context;
    }


    public async Task<User?> GetUserByEmail(string addressEmail)
    {
        return await _context.Users.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Email.Address == addressEmail);
    }

    public void Create(User user)
    {
        if (user is null)
            throw new ArgumentNullException(nameof(user));
        _context.Users.Add(user);
    }

    public void Update(User user)
    {
        if (user is null)
            throw new ArgumentNullException(nameof(user));
        _context.Users.Update(user);
    }

    public void Delete(User user)
    {
        if (user is null)
            throw new ArgumentNullException(nameof(user));
        _context.Users.Remove(user);
    }
}
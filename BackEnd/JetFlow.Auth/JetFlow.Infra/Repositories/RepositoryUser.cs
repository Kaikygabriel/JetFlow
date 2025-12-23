using Dapper;
using JetFlow.Domain.BackOffice.Entities;
using JetFlow.Domain.BackOffice.Interfaces;
using JetFlow.Domain.BackOffice.ObjectValues;
using JetFlow.Infra.Data.Context;
using JetFlow.Infra.DataDapper;
using JetFlow.Infra.DataDapper.Interface;
using Microsoft.EntityFrameworkCore;

namespace JetFlow.Infra.Repositories;

public class RepositoryUser : IRepositoryUser
{
    private readonly AppDbContext _context;
    private readonly IDbContextDapper _contextDapper;

    public RepositoryUser(AppDbContext appDbContext,IDbContextDapper contextDapper )
    {
        _contextDapper = contextDapper;
        _context = appDbContext;
    }


    public async Task<User?> GetUserByEmail(string addressEmail)
    {
        using var connection = _contextDapper.Create();
        var queryUser = @"SELECT [Id],[Name],[Password],[Email] FROM [Users] WHERE [Email] = @addressEmail";
            
        var user = await connection.QueryAsync<User,string,User>(queryUser,
            (user, email) =>
            {
                user.Email = new Email(email);
                return user;
            },new {addressEmail},splitOn:"Email");
        
        return user.FirstOrDefault();
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
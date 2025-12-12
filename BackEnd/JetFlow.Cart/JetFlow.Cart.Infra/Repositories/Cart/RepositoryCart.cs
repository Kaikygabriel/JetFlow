using System.Linq.Expressions;
using Dapper;
using DapperExtensions;
using JetFlow.Cart.Domain.BackOffice.Interfaces.Cart;
using JetFlow.Cart.Infra.Data.Contracts;
using Microsoft.Data.SqlClient;

namespace JetFlow.Cart.Infra.Repositories.Cart;

public class RepositoryCart : IRepositoryCart
{
    private readonly SqlConnection _connection;

    public RepositoryCart(IConnectionSql connectionSql)
    {
        _connection = connectionSql.CreateSqlConnection();
    }

    public async Task<IEnumerable<Domain.BackOffice.Entities.Cart>> GetAllAsync()
    {
        var query = "SELECT * FROM [Cart]";
        var result = await _connection.QueryAsync<Domain.BackOffice.Entities.Cart>(query);
        return result;
    }

    public async Task<Domain.BackOffice.Entities.Cart> GetByPredicate(Expression<Func<Domain.BackOffice.Entities.Cart, bool>> predicate)
    {
        var list = await _connection.GetListAsync<Domain.BackOffice.Entities.Cart>(predicate);

        return list.FirstOrDefault();
    }

    public async Task Create(Domain.BackOffice.Entities.Cart entity)
    {
        string query = @"INSERT INTO [Cart]([UserId],[LastUpdate]) VALUES (@UserIdOther,@LastDateOther)";
        await _connection.ExecuteAsync(query, new
        {
            UserIdOther = entity.UserId,
            LastDateOther = DateTime.UtcNow
        });
    }

    public async Task Update(Domain.BackOffice.Entities.Cart entity)
    {
        string query =
            @"UPDATE [Cart] SET [UserId] = @UserId, [LastUpdate] = @LastUpdate WHERE [Id] = @Id";
        await _connection.ExecuteAsync(query, new
        {
            UserId = entity.UserId,
            LastUpdate = DateTime.UtcNow
        });
    }

    public async Task Delete(Domain.BackOffice.Entities.Cart entity)
    {
        var query = @"DELETE FROM [Cart] WHERE [UserId] = @IdOther";
        await _connection.ExecuteAsync(query, new { IdOther = entity.UserId });
    }

    public async Task<Domain.BackOffice.Entities.Cart?> GetByUserId(int userId)
    {
        var query = @"SELECT * FROM [Cart] WHERE [UserId] = @Id";
        var result = await _connection.QueryFirstOrDefaultAsync<Domain.BackOffice.Entities.Cart>(query,new
        {
            Id = userId
        });
        return result;
    }
}
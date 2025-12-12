using System.Linq.Expressions;
using Dapper;
using DapperExtensions;
using JetFlow.Cart.Domain.BackOffice.Interfaces.CartItem;
using JetFlow.Cart.Infra.Data.Contracts;
using Microsoft.Data.SqlClient;

namespace JetFlow.Cart.Infra.Repositories.CartItem;

public class RepositoryCartItem : IRepositoryCartItem
{
    private readonly SqlConnection _connection;

    public RepositoryCartItem(IConnectionSql connectionSql)
    {
        _connection = connectionSql.CreateSqlConnection();
    }

    public async Task<IEnumerable<Domain.BackOffice.ObjectValue.CartItem>> GetAllAsync()
    {
        var query = @"SELECT * FROM [CartItem]";
        var result = await _connection.QueryAsync<Domain.BackOffice.ObjectValue.CartItem>(query);
        return result;
    }

    public async Task<IEnumerable<Domain.BackOffice.ObjectValue.CartItem>> GetAllByUserId(int userId)
    {
        var query = @"SELECT * FROM [CartItem] WHERE [UserId] = @UserId";
        var result = await _connection.QueryAsync<Domain.BackOffice.ObjectValue.CartItem>(query,new
        {
            userId
        });
        return result;
    }

    public async Task<Domain.BackOffice.ObjectValue.CartItem> GetById(int id)
    {
        var query = @"SELECT * FROM [CartItem] WHERE [Id] = @Id";
        var result = await _connection.QueryFirstAsync<Domain.BackOffice.ObjectValue.CartItem>(query,new
        {
            Id = id
        });
        return result;
    }

    public async Task<Domain.BackOffice.ObjectValue.CartItem> GetByPredicate(Expression<Func<Domain.BackOffice.ObjectValue.CartItem, bool>> predicate)
    {
        var result = await _connection.GetListAsync<Domain.BackOffice.ObjectValue.CartItem>(predicate);
        return result.FirstOrDefault();
    }

    public async Task Create(Domain.BackOffice.ObjectValue.CartItem entity)
    {
        var query = "INSERT INTO [CartItem] VALUES (@CartId,@Name,@Description,@ImageUrl,@Price,@Quant,@UserId)";
        await _connection.ExecuteAsync(query, new 
        {
            CartId = entity.IdCart,
            Name = entity.Name,
            Description = entity.Description,
            ImageUrl = entity.ImageUrl,
            Price=  entity.Price,
            Quant = entity.Quantity,
            UserId = entity.UserId
        });
    }

    public Task Update(Domain.BackOffice.ObjectValue.CartItem entity)
    {
        throw new NotImplementedException();
    }

    public async Task Delete(Domain.BackOffice.ObjectValue.CartItem entity)
    {
        var query = @"DELETE FROM [CartItem] WHERE [Id] = @IdOther";
        await _connection.ExecuteAsync(query, new
        {
            IdOther = entity.Id 
        });
    }

    
}
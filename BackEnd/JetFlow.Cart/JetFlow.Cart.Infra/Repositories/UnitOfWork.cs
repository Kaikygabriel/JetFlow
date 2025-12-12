using JetFlow.Cart.Domain.BackOffice.Interfaces;
using JetFlow.Cart.Domain.BackOffice.Interfaces.Cart;
using JetFlow.Cart.Domain.BackOffice.Interfaces.CartItem;
using JetFlow.Cart.Infra.Data;
using JetFlow.Cart.Infra.Data.Contracts;
using JetFlow.Cart.Infra.Repositories.Cart;
using JetFlow.Cart.Infra.Repositories.CartItem;

namespace JetFlow.Cart.Infra.Repositories;

public class UnitOfWork  : IUnitOfWork
{
    private readonly IConnectionSql _connectionSql;
    private RepositoryCart _repositoryCart;
    private RepositoryCartItem _repositoryCartItem;
    
    public UnitOfWork(IConnectionSql connectionSql)
    {
        _connectionSql = connectionSql;
    }

    public IRepositoryCartItem RepositoryCartItem
    {
        get
        {
            return _repositoryCartItem = _repositoryCartItem ?? new(_connectionSql);
        }
    }

    public IRepositoryCart RepositoryCart
    {
        get
        {
            return _repositoryCart = _repositoryCart ?? new(_connectionSql);
        }
    }

    public async Task CommitAsync()
    {
        await Task.Delay(0);
    }
}
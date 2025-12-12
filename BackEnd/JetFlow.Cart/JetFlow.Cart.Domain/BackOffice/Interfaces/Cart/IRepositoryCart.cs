namespace JetFlow.Cart.Domain.BackOffice.Interfaces.Cart;

public interface IRepositoryCart : IRepository<Entities.Cart>
{
    Task<Entities.Cart?> GetByUserId(int userId);
}
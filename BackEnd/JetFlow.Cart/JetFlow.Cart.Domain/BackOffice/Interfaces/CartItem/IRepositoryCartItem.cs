namespace JetFlow.Cart.Domain.BackOffice.Interfaces.CartItem;

public interface IRepositoryCartItem : IRepository<ObjectValue.CartItem>
{
    Task<IEnumerable<Domain.BackOffice.ObjectValue.CartItem>> GetAllByUserId(int userId);
    Task<Domain.BackOffice.ObjectValue.CartItem> GetById(int id);
}
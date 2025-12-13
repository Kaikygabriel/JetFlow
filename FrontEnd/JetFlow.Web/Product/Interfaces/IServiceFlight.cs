using JetFlow.Web.Product.Entitie;

namespace JetFlow.Web.Product.Interfaces;

public interface IServiceFlight
{
    Task<IEnumerable<Flight>?> GetAllAsync(int skip , int take);
    Task Create(Flight flight);
}
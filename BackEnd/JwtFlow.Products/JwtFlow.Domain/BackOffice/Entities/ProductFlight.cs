using JwtFlow.Domain.BackOffice.Entities.Contracts;
using JwtFlow.Domain.BackOffice.ObjectValue;

namespace JwtFlow.Domain.BackOffice.Entities;

public class ProductFlight : Entity
{
    protected ProductFlight()
    {
    }
    public ProductFlight(FlightDate flightDate, FlightCity flightCity, decimal price, string name)
    {
        IsValid(price,name);
        FlightDate = flightDate;
        FlightCity = flightCity;
        Price = price;
        Name = name;
    }

    public string Name { get; set; }
    public FlightDate FlightDate  { get; set; }
    public FlightCity FlightCity  { get; set; }
    public decimal Price { get; set; }

    public List<string> UsersId { get; private set; } = new();

    public void SetUsersId(string user)
        => UsersId.Add(user);

    public IEnumerable<string> GetUsersId()
        => UsersId; 
    
    private void IsValid(decimal price,string name)
    {
        if (price < 0 || string.IsNullOrEmpty(name))
            throw new Exception();
    }
}
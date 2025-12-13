namespace JetFlow.Web.Product.Entitie;

public class Flight
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public FlightDate FlightDate  { get; set; }
    public FlightCity FlightCity  { get; set; }
    public decimal Price { get; set; }
}
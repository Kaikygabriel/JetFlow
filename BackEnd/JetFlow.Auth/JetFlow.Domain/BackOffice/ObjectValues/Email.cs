namespace JetFlow.Domain.BackOffice.ObjectValues;

public struct Email
{
    public Email(string address)
    {
        Address = address;
    }
    public string Address { get;private set; }
    
}
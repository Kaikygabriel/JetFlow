using JetFlow.Domain.BackOffice.Entities.Contracts;
using JetFlow.Domain.BackOffice.ObjectValues;

namespace JetFlow.Domain.BackOffice.Entities;

public class User : Entity
{
    protected User()
    {
        
    }
    public User(string name, Email email, string password)
    {
        if (!IsValidAttributes(name, password))
            throw new System.Exception("Attributes invalid");
        Name = name;
        Email = email;
        Password = password;
    }

    public string Name { get;private set; }
    public Email Email { get;private set; }
    public string Password { get;private set; }
    public List<string> Roles { get; private set; } = new();
    
    public void AddRole(string role)
     => Roles.Add(role);

    public bool IsValidAttributes(string name, string password)
    {
        if (string.IsNullOrWhiteSpace(name) ||
            string.IsNullOrWhiteSpace(password) ||
            name.Length < 2 ||
            password.Length < 3)
            return false;
        return true;
    }
}
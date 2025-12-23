using JetFlow.Domain.BackOffice.Entities.Contracts;
using JetFlow.Domain.BackOffice.ObjectValues;

namespace JetFlow.Domain.BackOffice.Entities;

public class User : Entity
{
    public User()
    {
        
    }
    public User(string name, Email email, string password)
    {
        if (!IsValidName(name) || !IsValidPassword(password))
            throw new System.Exception("Attributes invalid");
        Name = name;
        Email = email;
        Password = password;
    }

    public string Name { get;set; }
    public Email Email { get; set; }
    public string Password { get; set; }
    public List<string> Roles { get; set; } = new(){ "Student"};
    
    public void AddRole(string role)
     => Roles.Add(role);
    
    public void AddRoles(params IEnumerable<string> roles)
        => Roles.AddRange(roles);

    public void UpdatePassword(string password)
    {
        if (!IsValidPassword(password))
            throw new System.Exception("Password Invalid");
        Password = password;
    }

    public bool IsValidPassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password) ||
            password.Length < 3)
            return false;
        return true;
    }

    public bool IsValidName(string name)
    {
        if (string.IsNullOrWhiteSpace(name) ||
            name.Length < 2 )
            return false;
        return true;
    }

}
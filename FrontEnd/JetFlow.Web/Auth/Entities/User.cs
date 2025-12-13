namespace JetFlow.Web.Auth.Entities;

public class User
{
    public string Name { get;private set; }
    public string Email { get;private set; }
    public string Password { get;private set; }
    public List<string> Roles { get; private set; } = new();
}
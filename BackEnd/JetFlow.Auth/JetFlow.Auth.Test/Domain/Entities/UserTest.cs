using JetFlow.Domain.BackOffice.Entities;
using JetFlow.Domain.BackOffice.ObjectValues;

namespace JetFlow.Auth.Test.Domain.Entities;

public class UserTest
{
    private readonly Email Email = new Email("teste@gmail.com");

    private const string NAME_VALID = "teste";
    private const string? NAME_NULL = null;
    
    private const string PASSWORD_VALID = "123@@@";
    private const string? PASSWORD_NULL = null;

    [Fact]
    public void CreateUser_WithPasswordAndNameNUll_Return_Exception()
    {
        Assert.Throws<Exception>(() =>
            new User(NAME_NULL, Email, PASSWORD_NULL));
    }

    [Fact]
    public void CreateUser_WithPasswordAndNameValid_Return_NotNull()
    {
        var user = new User(NAME_VALID,Email, PASSWORD_VALID);
        Assert.NotNull(user);
    }
}
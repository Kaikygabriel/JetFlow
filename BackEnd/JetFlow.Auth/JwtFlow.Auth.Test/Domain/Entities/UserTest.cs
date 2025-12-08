using JetFlow.Domain.BackOffice.Entities;
using JetFlow.Domain.BackOffice.ObjectValues;

namespace JwtFlow.Auth.Test.Domain.Entities;

public class UserTest
{
    private const string NAME_VALID = "teste";
    private const string NAME_INVALID = "aw";
    
    private const string PASSWORD_VALID = "teste123";
    private const string PASSWORD_INVALID = "aw";

    private Email Email = new("teste@gmail.com");

    [Fact]
    public void Should_Return_Exception_If_NameOrPassword_Invalid()
    {
        Assert.Throws<Exception>(()
            => new User(NAME_INVALID, Email, PASSWORD_INVALID));
    }
    [Fact]
    public void Should_Return_NotNull_If_NameAndPassword_Valid()
    {
        var user =new User(NAME_VALID, Email, PASSWORD_VALID);
        Assert.NotNull(user);
    }

    [Fact]
    public void Should_Get_Update_Password_If_PasswordValid()
    {
        var newPassword = "1234teste";
        var user =new User(NAME_VALID, Email, PASSWORD_VALID);
        user.UpdatePassword(newPassword);
        
        Assert.Equal(user.Password,newPassword);
    }
}
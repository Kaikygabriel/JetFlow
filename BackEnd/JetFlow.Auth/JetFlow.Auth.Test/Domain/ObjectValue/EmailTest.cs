using JetFlow.Domain.BackOffice.Exception;
using JetFlow.Domain.BackOffice.ObjectValues;

namespace JetFlow.Auth.Test.Domain.ObjectValue;

public class EmailTest
{
    private const string EMAIL_INVALID = "teste";
    private const string EMAIL_VALID = "teste@gmail.com";
    private const string? EMAIL_NULL = null;

    [Fact]
    public void CreateEmail_with_AddressInvalid_Return_EmailException()
    {
        Assert.Throws<EmailException>(() =>
            new Email(EMAIL_INVALID));
    }
    
    [Fact]
    public void CreateEmail_with_AddressNull_Return_Exception()
    {
        
        Assert.Throws<EmailException>(() =>
            new Email(EMAIL_NULL));
    }
    
    [Fact]
    public void CreateEmail_with_AddressValid_Return_NotNull()
    {
        var email = new Email(EMAIL_VALID);
        Assert.NotNull(email);
    }
}
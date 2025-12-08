using JetFlow.Domain.BackOffice.Exception;
using JetFlow.Domain.BackOffice.ObjectValues;

namespace JwtFlow.Auth.Test.Domain.ObjectValue;

public class EmailTest
{
    private const string? ADDRESS_NULL = null;
    private const string ADDRESS_VALID = "teste@gmail.com";
    private const string ADDRESS_INVALID = "teste";

    [Fact]
    public void Should_Return_Exception_If_AddressNull()
    {
        Assert.Throws<EmailException>(() =>
            new Email(ADDRESS_NULL));
    }
    [Fact]
    public void Should_Return_Exception_If_AddressInvalid()
    {
        Assert.Throws<EmailException>(() =>
            new Email(ADDRESS_INVALID));
    }
    [Fact]
    public void Should_Return_NotNull_If_AddressValid()
    {
        var email = new Email(ADDRESS_VALID);
        Assert.NotNull(email);
    }
}
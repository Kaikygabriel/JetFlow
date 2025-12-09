using JetFlow.Infra.DTOs.User;
using JetFlow.Infra.UseCases.User.Query.Login;

namespace JwtFlow.Auth.Test.Infra.UseCases.Query.Login;

public class LoginQueryTest : EntityTestBaseQuery
{
    private readonly LoginUserDTO USER_VALID = new(){Email = "admin@jetflow.com",Password = "admin123"};
    private readonly LoginUserDTO USER_NO_EXISTING = new(){Email = "teste@jetflow.com",Password = "teste@@teste"};
    private readonly LoginUserDTO USER_PASSWORD_INVALID = new(){Email = "admin@jetflow.com",Password = "teste"};

    [Fact]
    public async Task Should_Return_Null_if_UserNoExisting()
    {
        var query = new LoginQuery(USER_NO_EXISTING);
        var result = await HandlerCommand.Handle(query, default);
        Assert.Null(result);
    }
    
    [Fact]
    public async Task Should_Return_Null_if_UserWithPasswordInvalid()
    {
        var query = new LoginQuery(USER_PASSWORD_INVALID);
        var result = await HandlerCommand.Handle(query, default);
        Assert.Null(result);
    }
    
    [Fact]
    public async Task Should_Return_NotNull_if_UserValid()
    {
        var query = new LoginQuery(USER_VALID);
        var result = await HandlerCommand.Handle(query, default);
        Assert.NotNull(result);
    }
    
}
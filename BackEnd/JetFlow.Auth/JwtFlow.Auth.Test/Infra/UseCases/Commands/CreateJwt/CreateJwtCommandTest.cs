using JetFlow.Domain.BackOffice.Entities;
using JetFlow.Domain.BackOffice.ObjectValues;
using JetFlow.Infra.UseCases.User.Command.Create;
using JetFlow.Infra.UseCases.User.Command.CreateJwt;

namespace JwtFlow.Auth.Test.Infra.UseCases.Commands.CreateJwt;

public class CreateJwtCommandTest : EntityTestBaseCommand
{
    private readonly User USER_VALID =
        new User("Teste2", new Email("Teste2@jetflow.com"), "admin123");

    [Fact]
    public async Task Shoul_Return_NotNull_If_AuthorizationCodeIsValid()
    {
        var authorizationCode = await 
            HandlerCommand.Handle(new CreateCommand(USER_VALID),default);
        var result = await HandlerCommand.Handle(new CreateJwtCommand(authorizationCode), default);
        Assert.NotNull(result);
    }
    
    [Fact]
    public async Task Shoul_Return_Null_If_AuthorizationCodeIsInvalid()
    {
        var authorizationCode = Guid.NewGuid().ToString();
        var result = await HandlerCommand.Handle(new CreateJwtCommand(authorizationCode), default);
        Assert.Null(result);
    }
}
using JetFlow.Domain.BackOffice.Entities;
using JetFlow.Domain.BackOffice.ObjectValues;
using JetFlow.Infra.UseCases.User.Command.Create;

namespace JwtFlow.Auth.Test.Infra.UseCases.Commands.Create;

public class CreateCommandTest : EntityTestBaseCommand
{
    private readonly User USER_VALID =
        new User("Teste", new Email("Teste@jetflow.com"), "admin123");
    private readonly User USER_EXISTING =
        new User("John Admin", new Email("admin@jetflow.com"),"adimin123");
    
    [Fact]
    public async Task Should_Return_Null_If_UserExisting()
    {
        var command = new CreateCommand(USER_EXISTING);
        var result = await HandlerCommand.Handle(command,default);
        Assert.Null(result);
    }
    
    [Fact]
    public async Task Should_Return_NotNull_If_UserIsValid()
    {
        var command = new CreateCommand(USER_VALID);
        var result = await HandlerCommand.Handle(command,default);
        Assert.NotNull(result);
    }
}
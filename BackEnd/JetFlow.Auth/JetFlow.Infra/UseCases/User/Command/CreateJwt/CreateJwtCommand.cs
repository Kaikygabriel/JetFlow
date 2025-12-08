using MediatR;

namespace JetFlow.Infra.UseCases.User.Command.CreateJwt;

public record CreateJwtCommand(string Code) : IRequest<string?>;
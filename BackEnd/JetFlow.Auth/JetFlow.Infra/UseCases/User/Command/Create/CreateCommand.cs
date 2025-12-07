using MediatR;

namespace JetFlow.Infra.UseCases.User.Command.Create;

public record CreateCommand(Domain.BackOffice.Entities.User User) : IRequest<bool>;
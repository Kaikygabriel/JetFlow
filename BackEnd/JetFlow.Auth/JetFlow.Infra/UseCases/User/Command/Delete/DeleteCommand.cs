using MediatR;

namespace JetFlow.Infra.UseCases.User.Command.Delete;

public record DeleteCommand(string emailUser) : IRequest<bool>;


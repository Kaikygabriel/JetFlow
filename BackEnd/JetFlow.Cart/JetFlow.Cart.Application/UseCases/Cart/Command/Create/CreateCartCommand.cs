using MediatorX.Core.Abstraction.Interfaces;

namespace JetFlow.Cart.Application.UseCases.Cart.Command.Create;

public record CreateCartCommand(Domain.BackOffice.Entities.Cart Cart) : IRequest<bool>;
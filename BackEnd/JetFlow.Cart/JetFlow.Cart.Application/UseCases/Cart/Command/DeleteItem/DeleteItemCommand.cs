using MediatorX.Core.Abstraction.Interfaces;

namespace JetFlow.Cart.Application.UseCases.Cart.Command.DeleteItem;

public record DeleteItemCommand(int idCartItem,int userId) : IRequest<bool>;
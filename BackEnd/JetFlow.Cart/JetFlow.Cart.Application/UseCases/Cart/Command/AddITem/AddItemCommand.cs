using JetFlow.Cart.Domain.BackOffice.ObjectValue;
using MediatorX.Core.Abstraction.Interfaces;

namespace JetFlow.Cart.Application.UseCases.Cart.Command.AddITem;

public record AddItemCommand(int UserId , CartItem Item) : IRequest<bool>;
using MediatorX.Core.Abstraction.Interfaces;

namespace JetFlow.Cart.Application.UseCases.Cart.Query.GetCartByUserId;

public record GetCartByUserIdQuery(int UserId )  : IRequest<Domain.BackOffice.Entities.Cart?>;
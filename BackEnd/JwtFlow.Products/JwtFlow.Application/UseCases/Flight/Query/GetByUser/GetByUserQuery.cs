using JwtFlow.Domain.BackOffice.Entities;
using MediatorX.Core.Abstraction.Interfaces;

namespace JwtFlow.Application.UseCases.Flight.Query.GetByUser;

public record GetByUserQuery(string userId) :  IRequest<IEnumerable<ProductFlight>>;
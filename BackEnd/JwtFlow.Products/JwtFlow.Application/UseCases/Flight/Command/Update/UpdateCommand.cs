using JwtFlow.Domain.BackOffice.Entities;
using MediatorX.Core.Abstraction.Interfaces;

namespace JwtFlow.Application.UseCases.Flight.Command.Update;

public record UpdateCommand(ProductFlight Model,Guid Id) : IRequest<bool>;
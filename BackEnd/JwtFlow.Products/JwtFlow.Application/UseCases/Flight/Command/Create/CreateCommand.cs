using JwtFlow.Domain.BackOffice.Entities;
using MediatorX.Core.Abstraction.Interfaces;

namespace JwtFlow.Application.UseCases.Flight.Command.Create;

public record CreateCommand(ProductFlight Product) : IRequest<bool>;
using MediatorX.Core.Abstraction.Interfaces;

namespace JwtFlow.Application.UseCases.Flight.Command.Delete;

public record DeleteCommand(string IdFlight) : IRequest<bool>;
using MediatorX.Core.Abstraction.Interfaces;

namespace JwtFlow.Application.UseCases.Flight.Command.AddUserInFlight;

public record AddUserCommand(string UserId, string FlightId) : IRequest<bool>;
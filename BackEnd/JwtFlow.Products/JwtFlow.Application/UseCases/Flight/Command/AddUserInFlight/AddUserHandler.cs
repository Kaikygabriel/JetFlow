using JwtFlow.Domain.BackOffice.Interface;
using MediatorX.Core.Abstraction.Interfaces;

namespace JwtFlow.Application.UseCases.Flight.Command.AddUserInFlight;

public class AddUserHandler : HandlerBase, IHandler<AddUserCommand,bool>
{
    public AddUserHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async  Task<bool> HandleAsync(AddUserCommand request, CancellationToken cancellationToken = new CancellationToken())
    {
        if (!IsValidCommand(request))
            return false;
        var flightExisting = await _unitOfWork.RepositoryProductFlight
            .GetByPredicate(x => x.Id.ToString() == request.FlightId);
        if (flightExisting is null)
            return false;
        flightExisting.SetUsersId(request.UserId);
        _unitOfWork.RepositoryProductFlight.Update(flightExisting);
        await _unitOfWork.CommitAsync();
        return true;
    }

    private bool IsValidCommand(AddUserCommand command)
    {
        if (string.IsNullOrEmpty(command.FlightId) ||
            string.IsNullOrEmpty(command.UserId)||
            command.FlightId.Length < 5 ||
            command.UserId.Length < 5)
            return false;
        
        return true;
    }
}
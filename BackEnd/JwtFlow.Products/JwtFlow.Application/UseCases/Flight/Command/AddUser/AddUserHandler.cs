using JwtFlow.Domain.BackOffice.Interface;
using MediatorX.Core.Abstraction.Interfaces;

namespace JwtFlow.Application.UseCases.Flight.Command.AddUser;

public class AddUserHandler :  HandlerBase  , IHandler<AddUserCommand, bool>
{
    public AddUserHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<bool> HandleAsync(AddUserCommand request, CancellationToken cancellationToken = new CancellationToken())
    {
        try
        {
            var productFlight = await _unitOfWork.RepositoryProductFlight
                .GetByPredicate(x => x.Id.ToString() == request.FlightId);
            if (productFlight is null || string.IsNullOrEmpty(request.UserId)) 
                return false;
            productFlight.SetUsersId(request.UserId);
            _unitOfWork.RepositoryProductFlight.Update(productFlight);
            await _unitOfWork.CommitAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}
using JwtFlow.Domain.BackOffice.Entities;
using JwtFlow.Domain.BackOffice.Interface;
using MediatorX.Core.Abstraction.Interfaces;

namespace JwtFlow.Application.UseCases.Flight.Query.GetByUser;

public class GetByUserHandler : HandlerBase,IHandler<GetByUserQuery,IEnumerable<ProductFlight>>
{
    public GetByUserHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<IEnumerable<ProductFlight>> HandleAsync(GetByUserQuery request, CancellationToken cancellationToken = new CancellationToken())
    {
        if (string.IsNullOrEmpty(request.userId))
            return null;
        return await _unitOfWork.RepositoryProductFlight.GetAllByUserAsync(request.userId);
    }
}
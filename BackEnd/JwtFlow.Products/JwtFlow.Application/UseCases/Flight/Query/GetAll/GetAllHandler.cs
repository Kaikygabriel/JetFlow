using JwtFlow.Domain.BackOffice.Entities;
using JwtFlow.Domain.BackOffice.Interface;
using MediatorX.Core.Abstraction.Interfaces;

namespace JwtFlow.Application.UseCases.Flight.Query.GetAll;

public class GetAllHandler  : HandlerBase,IHandler<GetAllQuery,IEnumerable<ProductFlight>>
{
    public GetAllHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<IEnumerable<ProductFlight>> HandleAsync(GetAllQuery request, CancellationToken cancellationToken = new CancellationToken())
    {
        if (!IsValidRequest(request))
        {
            return await _unitOfWork.RepositoryProductFlight.GetAllAsync(0, 50);
        }
        return await _unitOfWork.RepositoryProductFlight.GetAllAsync(request.Skip, request.Take);
    }

    private bool IsValidRequest(GetAllQuery query)
    {
        if (query.Skip < 0 || query.Take < 0 || query.Take > 50)
            return false;
        return true;
    }
}
using JwtFlow.Domain.BackOffice.Interface;

namespace JwtFlow.Application.UseCases;

public abstract class HandlerBase
{
    protected readonly IUnitOfWork _unitOfWork;

    protected HandlerBase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
}
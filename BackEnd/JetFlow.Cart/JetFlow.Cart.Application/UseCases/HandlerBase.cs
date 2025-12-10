using JetFlow.Cart.Domain.BackOffice.Interfaces;

namespace JetFlow.Cart.Application.UseCases;

public abstract class HandlerBase
{
    protected IUnitOfWork UnitOfWork;

    protected HandlerBase(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }
}
using JetFlow.Domain.BackOffice.Interfaces;

namespace JetFlow.Infra.UseCases;

public abstract class HandlerBase
{
    protected IUnitOfWork UnitOfWork;

    public HandlerBase(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }
}
using JetFlow.Domain.BackOffice.Interfaces;
using JetFlow.Infra.UseCases.User.Command.Create;
using JetFlow.Infra.UseCases.User.Command.Delete;
using MediatR;

namespace JetFlow.Infra.UseCases.User.Command;

public class HandlerCommand : HandlerBase ,
    IRequestHandler<CreateCommand,bool>,
    IRequestHandler<DeleteCommand,bool>
{
    public HandlerCommand(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<bool> Handle(CreateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var userExisting = await UnitOfWork.RepositoryUser.GetUserByEmail(request.User.Email.Address);
            if (userExisting is not null)
                return false;
            var newPassword = BCrypt.Net.BCrypt.HashPassword(request.User.Password);
            request.User.UpdatePassword(newPassword);
            
            UnitOfWork.RepositoryUser.Create(request.User);
            await UnitOfWork.CommitAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> Handle(DeleteCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var user = await UnitOfWork.RepositoryUser.GetUserByEmail(request.emailUser);
            if (user is  null)
                return false;
            UnitOfWork.RepositoryUser.Delete(user);
            await UnitOfWork.CommitAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}
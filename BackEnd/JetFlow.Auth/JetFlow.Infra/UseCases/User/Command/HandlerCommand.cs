using System.Security.Claims;
using JetFlow.Domain.BackOffice.Interfaces;
using JetFlow.Infra.Services.Contracts;
using JetFlow.Infra.UseCases.User.Command.Create;
using JetFlow.Infra.UseCases.User.Command.CreateJwt;
using JetFlow.Infra.UseCases.User.Command.Delete;
using MediatR;

namespace JetFlow.Infra.UseCases.User.Command;

public class HandlerCommand : HandlerBase ,
    IRequestHandler<CreateCommand,string?>,
    IRequestHandler<DeleteCommand,bool>,
    IRequestHandler<CreateJwtCommand,string?>
{
    private readonly IServiceToken _serviceToken;
    public HandlerCommand(IUnitOfWork unitOfWork, IServiceToken serviceToken) : base(unitOfWork)
    {
        _serviceToken = serviceToken;
    }

    public async Task<string?> Handle(CreateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var userExisting = await UnitOfWork.RepositoryUser.GetUserByEmail(request.User.Email.Address);
            if (userExisting is not null)
                return null;
            var newPassword = BCrypt.Net.BCrypt.HashPassword(request.User.Password);
            request.User.UpdatePassword(newPassword);
            
            UnitOfWork.RepositoryUser.Create(request.User);
            await UnitOfWork.CommitAsync();
            
            
            var code = _serviceToken.GenerateAuthenticationCode(request.User.Email.Address);
            return code;
        }
        catch (Exception e)
        {
            return null;
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
    
    public async Task<string?> Handle(CreateJwtCommand request, CancellationToken cancellationToken)
    {
        var emailUser = _serviceToken.GetEmailUserOfAuthenticationCodeOrNull(request.Code);
        if (emailUser is null) return null;
        var user = await UnitOfWork.RepositoryUser.GetUserByEmail(emailUser);
        if (user is null) return null;
        var token = _serviceToken.GenerateAccessToken(GetClaimsOfUser(user));
        return token;
    }

    private IList<Claim> GetClaimsOfUser(Domain.BackOffice.Entities.User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Email, user.Email.Address)
        };
        foreach (var role in user.Roles)
            new Claim(ClaimTypes.Role, role);
        return claims;
    }

}
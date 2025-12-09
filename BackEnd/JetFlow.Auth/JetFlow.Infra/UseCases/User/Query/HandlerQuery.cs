using System.Security.Claims;
using JetFlow.Domain.BackOffice.Interfaces;
using JetFlow.Infra.Services;
using JetFlow.Infra.Services.Contracts;
using JetFlow.Infra.UseCases.User.Query.Login;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace JetFlow.Infra.UseCases.User.Query;

public class HandlerQuery : HandlerBase,
    IRequestHandler<LoginQuery,string?>
{
    private readonly IServiceToken _serviceToken;
    public HandlerQuery(IUnitOfWork unitOfWork, IServiceToken serviceToken) : base(unitOfWork)
    {
        _serviceToken = serviceToken;
    }

    public async Task<string?> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var user = await UnitOfWork.RepositoryUser.GetUserByEmail(request.UserDto.Email);
        if (user is null) return null;
        if (!VerifyPassword(request.UserDto.Password, user)) return null;

        var code = _serviceToken.GenerateAuthenticationCode(user.Email.Address);
        return code;
    }

    private bool VerifyPassword(string password, Domain.BackOffice.Entities.User user)
        => BCrypt.Net.BCrypt.Verify(password, user.Password);

}
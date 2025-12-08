using JetFlow.Infra.DTOs.User;
using MediatR;

namespace JetFlow.Infra.UseCases.User.Query.Login;

public record LoginQuery(LoginUserDTO UserDto) : IRequest<string?>;
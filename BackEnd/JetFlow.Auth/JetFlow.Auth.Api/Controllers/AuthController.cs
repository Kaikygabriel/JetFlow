using JetFlow.Domain.BackOffice.Entities;
using JetFlow.Infra.DTOs.User;
using JetFlow.Infra.UseCases.User.Command.Create;
using JetFlow.Infra.UseCases.User.Command.CreateJwt;
using JetFlow.Infra.UseCases.User.Query.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JetFlow.Auth.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("Cadastro")]
    public async Task<IActionResult> Cadastro([FromBody]CadastroUserDTO model)
    {
        User user = model;
        var result = await _mediator.Send(new CreateCommand(user));
        if (result is null) return BadRequest();

        return Ok(result);
    }
    
    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody]LoginUserDTO model)
    {
        var result = await _mediator.Send(new LoginQuery(model));
        if (result is null) return BadRequest();

        return Ok(result);
    }
    [HttpPost("GetTokenOfAuthorizationCode")]
    public async Task<IActionResult> GetTokenOfAuthorizationCode([FromBody]string token)
    {
        if (token is null || token.Length < 10)
            return NotFound();
        var result = await _mediator.Send(new CreateJwtCommand(token));
        if (result is null) return BadRequest();

        return Ok(result);
    }
}
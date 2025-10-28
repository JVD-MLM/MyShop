using System.ComponentModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyShop.Application.Requests.Commands.Authentication;

namespace MyShop.Api.Controllers.Authentication;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthenticationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("sign-up")]
    [Description("ثبت نام")]
    public async Task<IActionResult> SignUp([FromBody] SignUpRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new SignUpRequest
        {
            Email = request.Email,
            UserName = request.UserName,
            Password = request.Password
        });

        return Ok(response);
    }

    [HttpPost("sign-in")]
    [Description("ورود")]
    public async Task<IActionResult> SignIn([FromBody] SignInRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new SignInRequest
        {
            Email = request.Email,
            Password = request.Password
        });

        return Ok(response);
    }

    [HttpPost("sign-out")]
    [Description("خروج")]
    public async Task<IActionResult> SignOut([FromBody] SignOutRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new SignOutRequest
        {
            Token = request.Token
        });

        return Ok(response);
    }
}
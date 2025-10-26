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
    public async Task<IActionResult> SignUp([FromBody] SignUpRequest signUpRequest, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new SignUpRequest
        {
            UserName = signUpRequest.UserName,
            Email = signUpRequest.Email,
            Password = signUpRequest.Password
        });

        return Ok(result);
    }
}
using System.ComponentModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyShop.Application.DTOs.Authentication;
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
    public async Task<IActionResult> SignUp([FromBody] SignUpRequestDto request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new SignUpRequest
        {
            UserName = request.UserName,
            Email = request.Email,
            Password = request.Password
        });

        return Ok(result);
    }
}
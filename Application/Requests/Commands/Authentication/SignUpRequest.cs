using MediatR;
using MyShop.Application.Responses.Authentication;

namespace MyShop.Application.Requests.Commands.Authentication;

public class SignUpRequest : IRequest<SignUpRequestResponse>
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
}
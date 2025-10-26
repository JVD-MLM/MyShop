using MediatR;
using MyShop.Application.Responses.Authentication;

namespace MyShop.Application.Requests.Commands.Authentication;

public class SignInRequest : IRequest<SignInRequestResponse>
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public bool IsPersistent { get; set; }
}
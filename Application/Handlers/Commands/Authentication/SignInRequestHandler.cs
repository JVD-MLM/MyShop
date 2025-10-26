using MediatR;
using MyShop.Application.Requests.Commands.Authentication;
using MyShop.Application.Responses.Authentication;

namespace MyShop.Application.Handlers.Commands.Authentication;

public class SignInRequestHandler : IRequestHandler<SignInRequest, SignInRequestResponse>
{
    public Task<SignInRequestResponse> Handle(SignInRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
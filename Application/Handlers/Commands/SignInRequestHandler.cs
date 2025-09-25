using MediatR;
using MyShop.Application.DTOs.Authentication;
using MyShop.Application.Requests.Commands.Authentication;

namespace MyShop.Application.Handlers.Commands;

public class SignInRequestHandler : IRequestHandler<SignInRequest, SignInRequestResponse>
{
    public Task<SignInRequestResponse> Handle(SignInRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
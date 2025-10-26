using MediatR;
using MyShop.Application.Requests.Commands.Authentication;
using MyShop.Application.Responses.Authentication;

namespace MyShop.Application.Handlers.Commands.Authentication;

public class SignOutRequestHandler : IRequestHandler<SignOutRequest, SignOutRequestResponse>
{
    public Task<SignOutRequestResponse> Handle(SignOutRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
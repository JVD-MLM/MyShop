using MediatR;
using MyShop.Application.DTOs.Authentication;
using MyShop.Application.Requests.Commands.Authentication;

namespace MyShop.Application.Handlers.Commands;

public class SignOutRequestHandler : IRequestHandler<SignOutRequest, SignOutRequestResponse>
{
    public Task<SignOutRequestResponse> Handle(SignOutRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
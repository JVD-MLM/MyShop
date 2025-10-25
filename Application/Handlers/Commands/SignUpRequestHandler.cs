using MediatR;
using MyShop.Application.DTOs.Authentication;
using MyShop.Application.Requests.Commands.Authentication;

namespace MyShop.Application.Handlers.Commands;

public class SignUpRequestHandler : IRequestHandler<SignUpRequest, SignUpRequestResponse>
{
    public Task<SignUpRequestResponse> Handle(SignUpRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
using MediatR;
using MyShop.Application.Responses.Authentication;

namespace MyShop.Application.Requests.Commands.Authentication;

public class SignOutRequest : IRequest<SignOutRequestResponse>
{
}
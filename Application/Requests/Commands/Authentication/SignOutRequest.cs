using MediatR;
using MyShop.Application.DTOs.Authentication;

namespace MyShop.Application.Requests.Commands.Authentication;

public class SignOutRequest : IRequest<SignOutRequestResponse>
{
}
using MediatR;
using MyShop.Application.DTOs.Authentication;
using MyShop.Application.Responses.Authentication;

namespace MyShop.Application.Requests.Commands.Authentication;

public class SignUpRequest : IRequest<SignUpRequestResponse>
{
    public SignUpRequestDto SignUpRequestDto { get; set; }
}
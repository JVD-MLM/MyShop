using MediatR;
using Microsoft.AspNetCore.Identity;
using MyShop.Application.IRepositories;
using MyShop.Application.Requests.Commands.Authentication;
using MyShop.Application.Responses.Authentication;
using MyShop.Domain.Entities.Identity;
using MyShop.Domain.Entities.Jwt;

namespace MyShop.Application.Handlers.Commands.Authentication;

public class SignOutRequestHandler : IRequestHandler<SignOutRequest, SignOutRequestResponse>
{
    private readonly IJwtRepository _jwtRepository;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public SignOutRequestHandler(SignInManager<ApplicationUser> signInManager, IJwtRepository jwtRepository)
    {
        _signInManager = signInManager;
        _jwtRepository = jwtRepository;
    }

    public async Task<SignOutRequestResponse> Handle(SignOutRequest request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Token))
            return new SignOutRequestResponse { Message = "توکن معتبر ارسال نشده است." };

        var expireAt = DateTime.UtcNow.AddHours(1); // todo

        var revokedToken = new RevokedToken
        {
            Token = request.Token,
            ExpireAt = expireAt
        };

        await _jwtRepository.RevokeToken(revokedToken);

        await _signInManager.SignOutAsync();

        return new SignOutRequestResponse
        {
            Message = "با موفقیت خارج شدید"
        };
    }
}
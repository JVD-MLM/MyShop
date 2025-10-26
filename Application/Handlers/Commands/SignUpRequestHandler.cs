using MediatR;
using Microsoft.AspNetCore.Identity;
using MyShop.Application.DTOs.Authentication;
using MyShop.Application.Requests.Commands.Authentication;
using MyShop.Domain.Entities.Identity;

namespace MyShop.Application.Handlers.Commands;

public class SignUpRequestHandler : IRequestHandler<SignUpRequest, SignUpRequestResponse>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public SignUpRequestHandler(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<SignUpRequestResponse> Handle(SignUpRequest request, CancellationToken cancellationToken)
    {
        var user = new ApplicationUser
        {
            UserName = request.UserName,
            Email = request.Email
        };

        var createUser = await _userManager.CreateAsync(user, request.Password);

        if (createUser.Succeeded)
            return new SignUpRequestResponse
            {
                Message = "حساب کاربری با موفقیت ساخته شد"
            };

        throw new Exception("حساب کاربری ساخته نشد"); // todo: to IdentityException
    }
}
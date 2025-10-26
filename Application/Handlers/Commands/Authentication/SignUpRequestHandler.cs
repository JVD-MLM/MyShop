using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MyShop.Application.Requests.Commands.Authentication;
using MyShop.Application.Responses.Authentication;
using MyShop.Domain.Entities.Identity;

namespace MyShop.Application.Handlers.Commands.Authentication;

public class SignUpRequestHandler : IRequestHandler<SignUpRequest, SignUpRequestResponse>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IValidator<SignUpRequest> _validator;

    public SignUpRequestHandler(UserManager<ApplicationUser> userManager, IValidator<SignUpRequest> validator)
    {
        _userManager = userManager;
        _validator = validator;
    }

    public async Task<SignUpRequestResponse> Handle(SignUpRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

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
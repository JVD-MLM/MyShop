using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MyShop.Application.DTOs.Authentication;
using MyShop.Application.Requests.Commands.Authentication;
using MyShop.Application.Responses.Authentication;
using MyShop.Domain.Entities.Identity;

namespace MyShop.Application.Handlers.Commands.Authentication;

public class SignUpRequestHandler : IRequestHandler<SignUpRequest, SignUpRequestResponse>
{
    private readonly IMapper _mapper;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IValidator<SignUpRequestDto> _validator;

    public SignUpRequestHandler(UserManager<ApplicationUser> userManager, IValidator<SignUpRequestDto> validator,
        IMapper mapper)
    {
        _userManager = userManager;
        _validator = validator;
        _mapper = mapper;
    }

    public async Task<SignUpRequestResponse> Handle(SignUpRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request.SignUpRequestDto, cancellationToken);

        if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

        var user = _mapper.Map<ApplicationUser>(request.SignUpRequestDto);

        var createUser = await _userManager.CreateAsync(user, request.SignUpRequestDto.Password);

        if (createUser.Succeeded)
            return new SignUpRequestResponse
            {
                Message = "حساب کاربری با موفقیت ساخته شد"
            };

        throw new Exception("حساب کاربری ساخته نشد"); // todo: to IdentityException
    }
}
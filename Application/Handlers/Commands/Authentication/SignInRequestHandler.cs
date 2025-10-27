using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyShop.Application.Requests.Commands.Authentication;
using MyShop.Application.Responses.Authentication;
using MyShop.Domain.Entities.Identity;

namespace MyShop.Application.Handlers.Commands.Authentication;

public class SignInRequestHandler : IRequestHandler<SignInRequest, SignInRequestResponse>
{
    private readonly IConfiguration _configuration;
    private readonly UserManager<ApplicationUser> _userManager;

    public SignInRequestHandler(UserManager<ApplicationUser> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }

    public async Task<SignInRequestResponse> Handle(SignInRequest request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
        {
            var authClaims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Name, user.UserName),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var authSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:DurationInMinutes"])),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            var result = new SignInRequestResponse
            {
                Username = user.UserName,
                FirstName = user.FirstName ?? "",
                LastName = user.LastName ?? "",
                RoleName = "", // todo
                ExpiredAt = $"{token.ValidTo}",
                Token = "Bearer " + new JwtSecurityTokenHandler().WriteToken(token)
            };

            return result;
        }

        throw new Exception("کاربر یافت نشد");
    }
}
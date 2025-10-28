using MyShop.Domain.Entities.Jwt;

namespace MyShop.Application.IRepositories;

public interface IJwtRepository
{
    Task RevokeToken(RevokedToken token);
}
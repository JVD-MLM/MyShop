using MyShop.Application.IRepositories;
using MyShop.Domain.Entities.Jwt;

namespace MyShop.Infrastructure.Repositories;

public class JwtRepository : BaseRepository, IJwtRepository
{
    public JwtRepository(MyShopDbContext context) : base(context)
    {
    }

    public async Task RevokeToken(RevokedToken token)
    {
        await _context.RevokedTokens.AddAsync(token);
        await _context.SaveChangesAsync();
    }
}
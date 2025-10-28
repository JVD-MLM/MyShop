namespace MyShop.Infrastructure.Repositories;

public class BaseRepository
{
    protected readonly MyShopDbContext _context;

    public BaseRepository(MyShopDbContext context)
    {
        _context = context;
    }
}
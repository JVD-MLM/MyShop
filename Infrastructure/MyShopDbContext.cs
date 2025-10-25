using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyShop.Domain.Entities.Identity;

namespace MyShop.Infrastructure;

public class MyShopDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
{
    public MyShopDbContext(DbContextOptions<MyShopDbContext> options) : base(options)
    {
    }

    public DbSet<ApplicationUser> Users { get; set; }
}
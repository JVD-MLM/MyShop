using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MyShop.Infrastructure;

public class MyShopDbContextFactory : IDesignTimeDbContextFactory<MyShopDbContext>
{
    public MyShopDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<MyShopDbContext>();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("Default"));

        return new MyShopDbContext(optionsBuilder.Options);
    }
}
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MyFirstEFApp;

internal class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
{
    public ApplicationContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
         .SetBasePath(Directory.GetCurrentDirectory())
         .AddJsonFile("appconfig.json")
         .Build();

        var connectionString = config.GetConnectionString("DefaultConnection");

        return new ApplicationContext(connectionString!);
    }
}

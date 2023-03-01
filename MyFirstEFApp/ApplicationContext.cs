using Microsoft.EntityFrameworkCore;

namespace MyFirstEFApp;

internal class ApplicationContext : DbContext
{
    private readonly string _connectionString;

    public ApplicationContext(string connecttionString)
    {
        _connectionString = connecttionString;
        Database.EnsureCreated();
    }

    public ApplicationContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Client> Clients => Set<Client>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var serverVersion = ServerVersion.AutoDetect(_connectionString);
        optionsBuilder.UseMySql(_connectionString, serverVersion);
    }
}

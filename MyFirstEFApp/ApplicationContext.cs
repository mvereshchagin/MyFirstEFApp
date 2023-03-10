using Microsoft.EntityFrameworkCore;

namespace MyFirstEFApp;

internal class ApplicationContext : DbContext
{
    //private static bool isCreated = false;

    private readonly string _connectionString;

    private readonly StreamWriter _logStream = new StreamWriter(path: "logs.txt", append: true);

    public ApplicationContext(string connecttionString)
    {
        _connectionString = connecttionString;
        //if (!isCreated)
        //{
        //    // не используем в реальном приложении
        //    // в реальном приложении используем миграцию
        //    // Database.EnsureDeleted();
        //    Database.EnsureCreated();
        //    isCreated = true;
        //}
    }

    public ApplicationContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Client> Clients => Set<Client>();

    //public DbSet<Country> Countries => Set<Country>();

    public DbSet<Company> Companies => Set<Company>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var serverVersion = ServerVersion.AutoDetect(_connectionString);
        optionsBuilder.UseMySql(_connectionString, serverVersion);

        // логгирование в консоль. Не используется не практике!
        // optionsBuilder.LogTo(Console.WriteLine);

        // Вывод в окно дианостики. Используется только на стадии разработки
        // optionsBuilder.LogTo(message => System.Diagnostics.Debug.WriteLine(message));

        optionsBuilder.LogTo(
            action: _logStream.WriteLine, 
            minimumLevel: Microsoft.Extensions.Logging.LogLevel.Error,
            categories: new[] { DbLoggerCategory.Database.Command.Name });
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Fluent API
        modelBuilder.Entity<Country>()
            .ToTable("Countries")
            .Property(c => c.CurrencyName).HasColumnName("currency_name");

        // modelBuilder.Ignore<Country>();

        base.OnModelCreating(modelBuilder);
    }

    public override void Dispose()
    {
        base.Dispose();
        _logStream.Dispose();
    }
}

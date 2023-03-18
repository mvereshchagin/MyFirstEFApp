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

        // Database.EnsureDeleted();
        Database.EnsureCreated();

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

    }

    #region Tables
    public DbSet<Client> Clients => Set<Client>();

    public DbSet<UserProfile> Profiles => Set<UserProfile>();

    //public DbSet<Country> Countries => Set<Country>();

    public DbSet<Company> Companies => Set<Company>();

    public DbSet<Service> Services => Set<Service>();

    public DbSet<ClientService> ClientServices => Set<ClientService>();
    #endregion

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var serverVersion = ServerVersion.AutoDetect(_connectionString);
        optionsBuilder.UseMySql(_connectionString, serverVersion);

        // логгирование в консоль. Не используется не практике!
        // optionsBuilder.LogTo(Console.WriteLine);

        // Вывод в окно дианостики. Используется только на стадии разработки
        // optionsBuilder.LogTo(message => System.Diagnostics.Debug.WriteLine(message));

        // Lazy loading
        // optionsBuilder.UseLazyLoadingProxies();

        optionsBuilder.LogTo(
            action: _logStream.WriteLine, 
            // minimumLevel: Microsoft.Extensions.Logging.LogLevel.Error,
            categories: new[] { DbLoggerCategory.Database.Command.Name });
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Fluent API
        modelBuilder.Entity<Country>()
            .ToTable("Countries")
            .Property(c => c.CurrencyName).HasColumnName("currency_name");

        modelBuilder.Entity<Client>()
            .HasOne<Company>(c => c.Company)
            .WithMany(g => g.Clients)
            .HasForeignKey(s => s.CompanyId);

        //modelBuilder.Entity<Client>()
        //    .HasMany(x => x.Services)
        //    .WithMany(x => x.Clients)
        //    .UsingEntity(t => t.ToTable("clientservices"));

        // modelBuilder.Ignore<Country>();


        modelBuilder
            .Entity<Service>()
            .HasMany(s => s.Clients)
            .WithMany(c => c.Services)
            .UsingEntity<ClientService>(
                cs => cs
                    .HasOne(s => s.Client)
                    .WithMany(c => c.ClientServices)
                    .HasForeignKey(cs => cs.ClientId),
                cs => cs
                    .HasOne(s => s.Service)
                    .WithMany(c => c.ClientServices)
                    .HasForeignKey(cs => cs.ServiceId),
                cs =>
                {
                    cs.HasKey(cs2 => new { cs2.Id });
                    cs.ToTable("clientservices");
                });

        //modelBuilder.Entity<ClientService>()
        //    .HasKey(cs => new { cs.Id });

        //modelBuilder.Entity<ClientService>()
        //    .HasOne(s => s.Client)
        //    .WithMany(c => c.ClientServices)
        //    .HasForeignKey(cs => cs.ClientId);

        //modelBuilder.Entity<ClientService>()
        //    .HasOne(s => s.Service)
        //    .WithMany(c => c.ClientServices)
        //    .HasForeignKey(cs => cs.ServiceId);

        base.OnModelCreating(modelBuilder);
    }

    public override void Dispose()
    {
        base.Dispose();
        _logStream.Dispose();
    }
}

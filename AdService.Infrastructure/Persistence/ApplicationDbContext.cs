using AdService.Application.Common.Interfaces;
using AdService.Domain.Entities;
using AdService.Infrastructure.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AdService.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<Address> Addresses { get; set; }
    public DbSet<Advertisement> Advertisements { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Settings> Settings  { get; set; }
    public DbSet<SettingsPosition> SettingsPositions { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); // W tym miejscu zostaną zaaplikowane wszystkie konfiguracje implementujące typ EntityTypeBuilder - czyli klasy w folderze Configurations

        modelBuilder.SeedSettings();
        modelBuilder.SeedSettingsPositions();

        base.OnModelCreating(modelBuilder);
    }

}

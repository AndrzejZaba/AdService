using AdService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdService.Infrastructure.Persistence.Extensions;

static class ModelBuilderExtensionsSettings
{
    public static void SeedSettings(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Settings>().HasData(
            new Settings
            {
                Id = 1,
                Description = "E-mail",
                Order = 2
            },
            new Settings
            {
                Id = 2,
                Description = "General",
                Order = 1
            });
    }
}

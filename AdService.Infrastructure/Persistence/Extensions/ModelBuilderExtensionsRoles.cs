using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AdService.Infrastructure.Persistence.Extensions;

static class ModelBuilderExtensionsRoles
{
    public static void SeedRoles(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = "D850E215-F047-41C4-A036-FEB0020173DB",
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                ConcurrencyStamp = "A25D90F6-F95C-473C-AB27-F2FD5B156058"
            },
            new IdentityRole
            {
                Id = "56940798-D271-401E-8567-4C823BF87711",
                Name = "Client",
                NormalizedName = "CLIENT",
                ConcurrencyStamp = "21A2B715-F013-46EF-A378-B25DA1291E51"
            },
            new IdentityRole
            {
                Id = "3D39EE2F-950C-49CB-BAB1-C3DE9E6446C6",
                Name = "Worker",
                NormalizedName = "WORKER",
                ConcurrencyStamp = "593E74F5-8489-42AA-85C9-2863F72D8374"
            }
            );
            
    }
}

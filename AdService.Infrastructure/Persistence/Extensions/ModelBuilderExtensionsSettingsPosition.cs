using AdService.Application.Dictionaries;
using AdService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdService.Infrastructure.Persistence.Extensions;

static class ModelBuilderExtensionsSettingsPosition
{
    public static void SeedSettingsPositions(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SettingsPosition>().HasData(
            new SettingsPosition
            {
                Id = 1,
                Key = SettingsDict.HostSmtp,
                Value = "smtp.gmail.com",
                Description = "Host",
                Type = Domain.Enums.SettingsType.Text,
                SettingsId = 1,
                Order = 1
            },
            new SettingsPosition
            {
                Id = 2,
                Key = SettingsDict.Port,
                Value = "587",
                Description = "Port",
                Type = Domain.Enums.SettingsType.Text,
                SettingsId = 1,
                Order = 2
            },
            new SettingsPosition
            {
                Id = 3,
                Key = SettingsDict.SenderEmail,
                Value = "aswen124@gmail.com",
                Description = "Sender email address",
                Type = Domain.Enums.SettingsType.Text,
                SettingsId = 1,
                Order = 3
            },
            new SettingsPosition
            {
                Id = 4,
                Key = SettingsDict.SenderEmailPassword,
                Value = "",
                Description = "Sender password",
                Type = Domain.Enums.SettingsType.Password,
                SettingsId = 1,
                Order = 4
            },
            new SettingsPosition
            {
                Id = 5,
                Key = SettingsDict.SenderName,
                Value = "Andrzej Zaba",
                Description = "Sender name",
                Type = Domain.Enums.SettingsType.Text,
                SettingsId = 1,
                Order = 5
            },
            new SettingsPosition
            {
                Id = 6,
                Key = SettingsDict.SenderLogin,
                Value = "",
                Description = "Sender login",
                Type = Domain.Enums.SettingsType.Text,
                SettingsId = 1,
                Order = 6
            },
            new SettingsPosition
            {
                Id = 7,
                Key = SettingsDict.AdminEmail,
                Value = "andzab00@gmail.com",
                Description = "Admin email",
                Type = Domain.Enums.SettingsType.Text,
                SettingsId = 2,
                Order = 7
            }
            );
    }
}

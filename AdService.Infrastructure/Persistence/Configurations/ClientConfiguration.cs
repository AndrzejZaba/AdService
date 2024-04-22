using AdService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdService.Infrastructure.Persistence.Configurations;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("Clients");

        builder.Property(x => x.NipNumber)
            .HasMaxLength(15);

        builder.Property(x => x.UserId)
            .IsRequired();

        builder.Property(x => x.CompanyName)
            .HasMaxLength(200);

    }

}

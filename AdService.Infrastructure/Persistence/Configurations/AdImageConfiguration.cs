using AdService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdService.Infrastructure.Persistence.Configurations;

public class AdImageConfiguration : IEntityTypeConfiguration<AdImage>
{
    public void Configure(EntityTypeBuilder<AdImage> builder)
    {

        builder.ToTable("AdImages");

        builder.Property(x => x.Id)
            .IsRequired();

        builder.Property(x => x.ImageUrl)
            .HasMaxLength(100)
            .IsRequired();

        builder
            .HasOne(x => x.Advertisement)
            .WithMany(x => x.Images)
            .HasForeignKey(x => x.AdvertisementId)
            .OnDelete(DeleteBehavior.Restrict);
        
    }

}
using AdService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdService.Infrastructure.Persistence.Configurations;

public class AdvertisementConfiguration : IEntityTypeConfiguration<Advertisement>
{
    public void Configure(EntityTypeBuilder<Advertisement> builder)
    {

        builder.ToTable("Advertisements");

        builder.Property(x => x.Id)
            .IsRequired();
        
        builder.Property(x => x.Title)
            .HasMaxLength(300)
            .IsRequired();
        
        builder.Property(x => x.Description)
            .IsRequired();

        builder.Property(x => x.Price)
           .IsRequired();

        builder.Property(x => x.WebsiteUrl)
           .IsUnicode(false);

        builder
            .HasOne(x => x.User)
            .WithMany(x => x.Advertisements)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasOne(x => x.Category)
            .WithMany(x => x.Advertisements)
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

    }


}
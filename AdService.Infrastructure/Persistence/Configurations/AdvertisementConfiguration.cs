using AdService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdService.Infrastructure.Persistence.Configurations;

public abstract class AdvertisementConfiguration<T> : IEntityTypeConfiguration<T> where T : Advertisement
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {

        builder.ToTable("Advertisements");

        builder.Property(x => x.Id)
            .IsRequired();

        builder.Property(x => x.UserId) 
            .IsRequired();
        
        builder.Property(x => x.CategoryId) 
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

        //builder
        //    .HasOne(x => x.Category)
        //    .WithMany(x => x.Advertisements)
        //    .HasForeignKey(x => x.CategoryId)
        //    .OnDelete(DeleteBehavior.Restrict);

    }


}

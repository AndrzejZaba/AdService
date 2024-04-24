using AdService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace AdService.Infrastructure.Persistence.Configurations;

public class JobAdvertConfiguration : IEntityTypeConfiguration<JobAdvert>
{
    public void Configure(EntityTypeBuilder<JobAdvert> builder)
    {
        builder.ToTable("JobAdverts");

        builder.Property(x => x.Id)
            .IsRequired();

        builder.Property(x => x.Title)
            .HasMaxLength(300)
            .IsRequired();

        builder.Property(x => x.Description)
            .IsRequired();

        builder.Property(x => x.Price)
            .IsRequired();

        builder.Property(x => x.Location)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.WebsiteUrl)
            .IsUnicode(false);



        builder.Property(x => x.UserId)
            .IsRequired();

        builder.Property(x => x.CategoryId)
            .IsRequired();

        builder
            .HasOne(x => x.User)
            .WithMany(x => x.JobAdverts)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Category)
           .WithMany(x => x.JobAdverts) // Now referencing the correct collection
           .HasForeignKey(x => x.CategoryId)
           .OnDelete(DeleteBehavior.Restrict);
    }
}

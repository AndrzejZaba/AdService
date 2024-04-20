using AdService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace AdService.Infrastructure.Persistence.Configurations;

public class JobAdvertConfiguration : AdvertisementConfiguration<JobAdvert>
{
    public override void Configure(EntityTypeBuilder<JobAdvert> builder)
    {
        base.Configure(builder);

        builder.ToTable("JobAdverts");

        builder
            .HasOne(x => x.User)
            .WithMany(x => x.JobAdverts)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(j => j.Category)
           .WithMany(c => c.JobAdverts) // Now referencing the correct collection
           .HasForeignKey(j => j.CategoryId)
           .OnDelete(DeleteBehavior.Restrict);
    }
}


public class CourseAdvertConfiguration : AdvertisementConfiguration<CourseAdvert>
{
    public override void Configure(EntityTypeBuilder<CourseAdvert> builder)
    {
        base.Configure(builder);

        builder.ToTable("CourseAdverts");

        builder.Property(x => x.CoursePrice)
            .IsRequired();

        builder
            .HasOne(x => x.User)
            .WithMany(x => x.CourseAdverts)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(j => j.Category)
           .WithMany(c => c.CourseAdverts) // Now referencing the correct collection
           .HasForeignKey(j => j.CategoryId)
           .OnDelete(DeleteBehavior.Restrict);
    }
}
using AdService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdService.Application.Common.Interfaces;

public interface IApplicationDbContext : IDisposable
{
    DbSet<Address> Addresses { get; set; }
    DbSet<JobAdvert> JobAdverts { get; set; }
    DbSet<CourseAdvert> CourseAdverts { get; set; }
    DbSet<Client> Clients { get; set; }
    DbSet<Category> Categories { get; set; }
    DbSet<Settings> Settings { get; set; }
    DbSet<SettingsPosition> SettingsPositions { get; set; }
    DbSet<ApplicationUser> Users { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default); 
}

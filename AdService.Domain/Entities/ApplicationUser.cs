using Microsoft.AspNetCore.Identity;

namespace AdService.Domain.Entities;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime RegisterDateTime { get; set; }
    public bool IsDeleted { get; set; }
    public string WebsiteUrl { get; set; }


    public Address Address { get; set; }
    public Client Client { get; set; }
    public ICollection<JobAdvert> JobAdverts { get; set; } = new HashSet<JobAdvert>();
    public ICollection<CourseAdvert> CourseAdverts { get; set; } = new HashSet<CourseAdvert>();
}

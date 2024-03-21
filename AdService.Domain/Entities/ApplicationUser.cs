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
    public ICollection<Advertisement> Advertisements { get; set; } = new HashSet<Advertisement>();
}

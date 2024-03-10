namespace AdService.Domain.Entities;

public class ApplicationUser
{
    public string Id { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime RegisterDateTime { get; set; }
    public bool IsDeleted { get; set; }


    public Address Address { get; set; }
    public Client Client { get; set; }
    public ICollection<Advertisement> Advertisements { get; set; } = new HashSet<Advertisement>();
}

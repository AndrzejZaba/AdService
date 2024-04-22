

namespace AdService.Domain.Entities;

public class JobAdvert : Advertisement
{
    public decimal Salary { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public string UserId { get; set; }
    public ApplicationUser User { get; set; }
}

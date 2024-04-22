

namespace AdService.Domain.Entities;

public class CourseAdvert : Advertisement
{
    public string Id { get; set; }
    public decimal CoursePrice { get; set; }
    public string CourseImage { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public string UserId { get; set; }
    public ApplicationUser User { get; set; }
}

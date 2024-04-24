namespace AdService.Domain.Entities;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<JobAdvert> JobAdverts { get; set; } = new HashSet<JobAdvert>();
    public ICollection<CourseAdvert> CourseAdverts { get; set; } = new HashSet<CourseAdvert>();
}
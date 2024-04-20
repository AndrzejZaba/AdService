namespace AdService.Domain.Entities;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    //public ICollection<Advertisement> Advertisements { get; set; } = new HashSet<Advertisement>();
    // Separate collections for each derived type
    public ICollection<JobAdvert> JobAdverts { get; set; } = new HashSet<JobAdvert>();
    public ICollection<CourseAdvert> CourseAdverts { get; set; } = new HashSet<CourseAdvert>();
}
namespace AdService.Domain.Entities;

public abstract class Advertisement
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }

    // needs to be added in Database (with migration and db-update)
    public string Location { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime CreationDate { get; set; }
    public string WebsiteUrl { get; set; }


}
namespace AdService.Domain.Entities;

public class AdImage
{
    public string Id { get; set; }
    public string ImageUrl { get; set; }

    public string AdvertisementId { get; set; }
    public Advertisement Advertisement { get; set; }
}

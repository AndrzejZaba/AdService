namespace AdService.Domain.Entities;

public class Client
{
    public int Id { get; set; }
    public bool IsBusinessAccount { get; set; }
    public string NipNumber { get; set; }
    public string CompanyName { get; set; }
    public string CompanyLogo { get; set; }

    public string UserId { get; set; }
    public ApplicationUser User { get; set; }
}
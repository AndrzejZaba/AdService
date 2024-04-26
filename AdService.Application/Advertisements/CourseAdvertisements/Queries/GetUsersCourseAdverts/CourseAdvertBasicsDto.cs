namespace AdService.Application.Advertisements.CourseAdvertisements.Queries.GetUsersCourseAdverts
{
    public class CourseAdvertBasicsDto
    {
        public string Title { get; set; }
        public decimal CoursePrice { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime StartDate { get; set; }

        public string WebsiteUrl { get; set; }
    }
}
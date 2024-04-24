using AdService.Application.Advertisements.CourseAdvertisements.Queries;
using AdService.Domain.Entities;


namespace AdService.Application.Categories.Extensions;

public static class CategoryExtensions
{
    public static CategoryDto ToDto(this Category category)
    {
        if (category == null) 
            return null;

        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name
        };
    }
}

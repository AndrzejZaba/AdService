using AdService.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdService.Infrastructure.Persistence.Extensions;

public static class ModelBuilderExtensionsCategories
{
    public static void SeedCategories(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = 1,
                Name = "Administration"
            },
            new Category
            {
                Id = 2,
                Name = "Data Analysis"
            },
            new Category
            {
                Id = 3,
                Name = "IT"
            },
            new Category
            {
                Id = 4,
                Name = "Finances"
            });

    }
}

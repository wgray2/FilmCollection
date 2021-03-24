using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmCollection.Models
{
    public class SeedData
    {
        //No actual data, but necessary to initialize the database and make migrations
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            MovDbContext context = application.ApplicationServices.
                CreateScope().ServiceProvider.GetRequiredService<MovDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }
    }
}

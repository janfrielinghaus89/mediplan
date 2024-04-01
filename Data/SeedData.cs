using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MEDIplan.Models;

namespace MEDIplan.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                // Check if Wards are available
                if (context.Wards.Any())
                {
                    return;   // Database already populated
                }

                context.Wards.AddRange(
                    new Ward { Name = "Station 1" },
                    new Ward { Name = "Station 2" },
                    new Ward { Name = "Station 3" },
                    new Ward { Name = "Station 4" },
                    new Ward { Name = "Station 5" },
                    new Ward { Name = "Innere Medizin" },
                    new Ward { Name = "Chirurgie" },
                    new Ward { Name = "Orthopädie" },
                    new Ward { Name = "Neurologie" },
                    new Ward { Name = "Psychiatrie" },
                    new Ward { Name = "Gynäkologie" },
                    new Ward { Name = "Pädiatrie" },
                    new Ward { Name = "Intensivstation" },
                    new Ward { Name = "Notaufnahme" }
                );

                context.SaveChanges();
            }
        }
    }
}

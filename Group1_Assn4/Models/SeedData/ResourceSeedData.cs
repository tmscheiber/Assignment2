using Microsoft.AspNetCore.Builder;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Group1_Assn4.Models
{
    public static class ResourceSeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Resources.Any())
            {
                context.Resources.AddRange(
                    new Resource
                    {
                        ResourceName = "Resource 1",
                        HourlyRate = decimal.Parse("75.00"),
                        ServiceYears = 15,
                        Role = "Lead"
                    },
                    new Resource
                    {
                        ResourceName = "Resource 2",
                        HourlyRate = decimal.Parse("120.00"),
                        ServiceYears = 15,
                        Role = "Senior Manager"
                    },
                    new Resource
                    {
                        ResourceName = "Resource 3",
                        HourlyRate = decimal.Parse("90.00"),
                        ServiceYears = 15,
                        Role = "Software Consultant"
                    },
                    new Resource
                    {
                        ResourceName = "Resource 4",
                        HourlyRate = decimal.Parse("100.00"),
                        ServiceYears = 10,
                        Role = "Manager"
                    },
                    new Resource
                    {
                        ResourceName = "Resource 5",
                        HourlyRate = decimal.Parse("75.00"),
                        ServiceYears = 5,
                        Role = "Lead"
                    },
                    new Resource
                    {
                        ResourceName = "Resource 6",
                        HourlyRate = decimal.Parse("120.00"),
                        ServiceYears = 12,
                        Role = "Senior Manager"
                    },
                    new Resource
                    {
                        ResourceName = "Resource 7",
                        HourlyRate = decimal.Parse("90.00"),
                        ServiceYears = 6,
                        Role = "Software Consultant"
                    },
                    new Resource
                    {
                        ResourceName = "Resource 8",
                        HourlyRate = decimal.Parse("100.00"),
                        ServiceYears = 4,
                        Role = "Software Consultant"
                    },
                      new Resource
                      {
                          ResourceName = "Resource 9",
                          HourlyRate = decimal.Parse("65.00"),
                          ServiceYears = 1,
                          Role = "Project Manager"
                      },
                    new Resource
                    {
                        ResourceName = "Resource 10",
                        HourlyRate = decimal.Parse("100.00"),
                        ServiceYears = 10,
                        Role = "Manager"
                    }
                );
                context.SaveChanges();
            }// end if
        }//end static

    }// end class
}// end namespace

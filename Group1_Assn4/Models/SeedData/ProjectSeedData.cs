using Microsoft.AspNetCore.Builder;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;

namespace Group1_Assn4.Models
{
    public static class ProjectSeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Projects.Any())
            {
                context.Projects.AddRange(
                    new Project
                    {
                        ProjectName = "Project 1",
                        ClientID = 1,
                        DeliveryDate = DateTime.Parse("10/02/2020"),
                        KickOffDate = DateTime.Parse("1/02/2017"),
                        Status = "In Progress",
                        Revenue = decimal.Parse("6000000.00")
                    },
                    new Project
                    {
                        ProjectName = "Project 2",
                        ClientID = 1,
                        DeliveryDate = DateTime.Parse("1/01/2019"),
                        KickOffDate = DateTime.Parse("1/02/2014"),
                        Status = "Testing",
                        Revenue = decimal.Parse("1500000.00")
                    },
                    new Project
                    {
                        ProjectName = "Project 3",
                        ClientID = 1,
                        DeliveryDate = DateTime.Parse("1/01/2019"),
                        KickOffDate = DateTime.Parse("1/02/2017"),
                        Status = "In Progress",
                        Revenue = decimal.Parse("1200000.00")
                    },
                    new Project
                    {
                        ProjectName = "Project 4",
                        ClientID = 4,
                        DeliveryDate = DateTime.Parse("1/01/2020"),
                        KickOffDate = DateTime.Parse("1/02/2015"),
                        Status = "Testing",
                        Revenue = decimal.Parse("2100000.00")
                    },
                    new Project
                    {
                        ProjectName = "Project 5",
                        ClientID = 9,
                        DeliveryDate = DateTime.Parse("1/01/2023"),
                        KickOffDate = DateTime.Parse("1/02/2021"),
                        Status = "Not Started",
                        Revenue = decimal.Parse("6500000.00")
                    },
                    new Project
                    {
                        ProjectName = "Project 6",
                        ClientID = 3,
                        DeliveryDate = DateTime.Parse("1/01/2021"),
                        KickOffDate = DateTime.Parse("1/02/2017"),
                        Status = "Testing",
                        Revenue = decimal.Parse("2300000.00")
                    },
                    new Project
                    {
                        ProjectName = "Project 7",
                        ClientID = 5,
                        DeliveryDate = DateTime.Parse("1/01/2021"),
                        KickOffDate = DateTime.Parse("1/02/2017"),
                        Status = "In Progress",
                        Revenue = decimal.Parse("3500000.00")
                    },
                    new Project
                    {
                        ProjectName = "Project 8",
                        ClientID = 1,
                        DeliveryDate = DateTime.Parse("1/01/2020"),
                        KickOffDate = DateTime.Parse("1/02/2016"),
                        Status = "In Progress",
                        Revenue = decimal.Parse("4000000.00")
                    },
                    new Project
                    {
                        ProjectName = "Project 9",
                        ClientID = 2,
                        DeliveryDate = DateTime.Parse("1/01/2019"),
                        KickOffDate = DateTime.Parse("1/02/2009"),
                        Status = "Testing",
                        Revenue = decimal.Parse("2500000.00")
                    },
                    new Project
                    {
                        ProjectName = "Project 10",
                        ClientID = 5,
                        DeliveryDate = DateTime.Parse("1/01/2025"),
                        KickOffDate = DateTime.Parse("1/02/2022"),
                        Status = "Not Started",
                        Revenue = decimal.Parse("1000000.00")
                    },
                    new Project
                    {
                        ProjectName = "Project 11",
                        ClientID = 4,
                        DeliveryDate = DateTime.Parse("1/01/2020"),
                        KickOffDate = DateTime.Parse("1/02/2012"),
                        Status = "Testing",
                        Revenue = decimal.Parse("3000000.00")
                    },
                    new Project
                    {
                        ProjectName = "Project 12",
                        ClientID = 8,
                        DeliveryDate = DateTime.Parse("1/01/2019"),
                        KickOffDate = DateTime.Parse("1/02/2014"),
                        Status = "Testing",
                        Revenue = decimal.Parse("1000000.00")
                    },
                    new Project
                    {
                        ProjectName = "Project 13",
                        ClientID = 9,
                        DeliveryDate = DateTime.Parse("1/01/2022"),
                        KickOffDate = DateTime.Parse("1/02/2019"),
                        Status = "Not Started",
                        Revenue = decimal.Parse("2500000.00")
                    },
                    new Project
                    {
                        ProjectName = "Project 14",
                        ClientID = 6,
                        DeliveryDate = DateTime.Parse("1/01/2021"),
                        KickOffDate = DateTime.Parse("1/02/2010"),
                        Status = "Testing",
                        Revenue = decimal.Parse("1000000.00")
                    },
                    new Project
                    {
                        ProjectName = "Project 15",
                        ClientID = 7,
                        DeliveryDate = DateTime.Parse("1/01/2022"),
                        KickOffDate = DateTime.Parse("1/02/2020"),
                        Status = "Not Started",
                        Revenue = decimal.Parse("1500000.00")
                    }
                );
                context.SaveChanges();
            }// end if
        }//end static

    }// end class
}// end namespace
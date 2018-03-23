using Microsoft.AspNetCore.Builder;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Group1_Assn4.Models
{
    public static class ProjectResourceSeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.ProjectResources.Any())
            {
                context.ProjectResources.AddRange(
                    new ProjectResource
                    {
                        ProjectID = 1,
                        ResourceID = 1,
                        AllocatedHours = 2500
                    },
                    new ProjectResource
                    {
                        ProjectID = 1,
                        ResourceID = 2,
                        AllocatedHours = 1500
                    },
                    new ProjectResource
                    {
                        ProjectID = 1,
                        ResourceID = 3,
                        AllocatedHours = 2000
                    },
                    new ProjectResource
                    {
                        ProjectID = 1,
                        ResourceID = 7,
                        AllocatedHours = 1000
                    },
                    new ProjectResource
                    {
                        ProjectID = 2,
                        ResourceID = 1,
                        AllocatedHours = 100
                    },
                     new ProjectResource
                     {
                         ProjectID = 2,
                         ResourceID = 2,
                         AllocatedHours = 500
                     },
                    new ProjectResource
                    {
                        ProjectID = 2,
                        ResourceID = 3,
                        AllocatedHours = 1000
                    },
                    new ProjectResource
                    {
                        ProjectID = 2,
                        ResourceID = 5,
                        AllocatedHours = 556
                    },
                    new ProjectResource
                    {
                        ProjectID = 3,
                        ResourceID = 5,
                        AllocatedHours = 1511
                    },
                    new ProjectResource
                    {
                        ProjectID = 3,
                        ResourceID = 9,
                        AllocatedHours = 2080
                    },
                     new ProjectResource
                     {
                         ProjectID = 3,
                         ResourceID = 8,
                         AllocatedHours = 500
                     },
                    new ProjectResource
                    {
                        ProjectID = 4,
                        ResourceID = 6,
                        AllocatedHours = 1000
                    },
                    new ProjectResource
                    {
                        ProjectID = 4,
                        ResourceID = 5,
                        AllocatedHours = 500
                    },
                    new ProjectResource
                    {
                        ProjectID = 4,
                        ResourceID = 10,
                        AllocatedHours = 600
                    },
                    new ProjectResource
                    {
                        ProjectID = 5,
                        ResourceID = 6,
                        AllocatedHours = 400
                    },
                     new ProjectResource
                     {
                         ProjectID = 5,
                         ResourceID = 9,
                         AllocatedHours = 1000
                     },
                    new ProjectResource
                    {
                        ProjectID = 5,
                        ResourceID = 8,
                        AllocatedHours = 500
                    },
                    new ProjectResource
                    {
                        ProjectID = 5,
                        ResourceID = 7,
                        AllocatedHours = 1200
                    },
                    new ProjectResource
                    {
                        ProjectID = 6,
                        ResourceID = 10,
                        AllocatedHours = 2080
                    },
                    new ProjectResource
                    {
                        ProjectID = 6,
                        ResourceID = 5,
                        AllocatedHours = 900
                    },
                     new ProjectResource
                     {
                         ProjectID = 6,
                         ResourceID = 3,
                         AllocatedHours = 1500
                     },
                    new ProjectResource
                    {
                        ProjectID = 7,
                        ResourceID = 7,
                        AllocatedHours = 2080
                    },
                    new ProjectResource
                    {
                        ProjectID = 7,
                        ResourceID = 1,
                        AllocatedHours = 900
                    },
                    new ProjectResource
                    {
                        ProjectID = 7,
                        ResourceID = 10,
                        AllocatedHours = 1511
                    },
                    new ProjectResource
                    {
                        ProjectID = 8,
                        ResourceID = 1,
                        AllocatedHours = 1511
                    },
                     new ProjectResource
                     {
                         ProjectID = 8,
                         ResourceID = 1,
                         AllocatedHours = 1511
                     },
                    new ProjectResource
                    {
                        ProjectID = 8,
                        ResourceID = 7,
                        AllocatedHours = 1511
                    },
                    new ProjectResource
                    {
                        ProjectID = 8,
                        ResourceID = 5,
                        AllocatedHours = 1511
                    },
                    new ProjectResource
                    {
                        ProjectID = 9,
                        ResourceID = 5,
                        AllocatedHours = 600
                    },
                    new ProjectResource
                    {
                        ProjectID = 9,
                        ResourceID = 3,
                        AllocatedHours = 1000
                    },
                    new ProjectResource
                    {
                        ProjectID = 9,
                        ResourceID = 9,
                        AllocatedHours = 1511
                    },
                    new ProjectResource
                    {
                        ProjectID = 10,
                        ResourceID = 9,
                        AllocatedHours = 200
                    },
                    new ProjectResource
                    {
                        ProjectID = 10,
                        ResourceID = 6,
                        AllocatedHours = 1511
                    },
                    new ProjectResource
                    {
                        ProjectID = 10,
                        ResourceID = 7,
                        AllocatedHours = 600
                    },

                    new ProjectResource
                    {
                        ProjectID = 11,
                        ResourceID = 8,
                        AllocatedHours = 200
                    },
                    new ProjectResource
                    {
                        ProjectID = 11,
                        ResourceID = 1,
                        AllocatedHours = 1511
                    },
                    new ProjectResource
                    {
                        ProjectID = 11,
                        ResourceID = 7,
                        AllocatedHours = 600
                    },

                       new ProjectResource
                       {
                           ProjectID = 12,
                           ResourceID = 10,
                           AllocatedHours = 2000
                       },
                    new ProjectResource
                    {
                        ProjectID = 12,
                        ResourceID = 5,
                        AllocatedHours = 1600
                    },
                    new ProjectResource
                    {
                        ProjectID = 12,
                        ResourceID = 3,
                        AllocatedHours = 900
                    },
                        new ProjectResource
                        {
                            ProjectID = 13,
                            ResourceID = 2,
                            AllocatedHours = 2000
                        },
                    new ProjectResource
                    {
                        ProjectID = 13,
                        ResourceID = 5,
                        AllocatedHours = 1600
                    },
                    new ProjectResource
                    {
                        ProjectID = 14,
                        ResourceID = 5,
                        AllocatedHours = 900
                    },
                      new ProjectResource
                      {
                          ProjectID = 14,
                          ResourceID = 9,
                          AllocatedHours = 1200
                      },
                        new ProjectResource
                        {
                            ProjectID = 14,
                            ResourceID = 6,
                            AllocatedHours = 700
                        },

                          new ProjectResource
                          {
                              ProjectID = 15,
                              ResourceID = 8,
                              AllocatedHours = 500
                          },
                            new ProjectResource
                            {
                                ProjectID = 15,
                                ResourceID = 6,
                                AllocatedHours = 700
                            },
                    new ProjectResource
                    {
                        ProjectID = 15,
                        ResourceID = 1,
                        AllocatedHours = 800
                    }
                );
                context.SaveChanges();
            }// end if
        }//end static
      }// end class
}// end namespace
 
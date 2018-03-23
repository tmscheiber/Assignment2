using Microsoft.AspNetCore.Builder;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Group1_Assn4.Models
{
    public static class ClientSeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Clients.Any())
            {
                context.Clients.AddRange(
                    new Client
                    {
                        ClientName = "Customer 1",
                        Region = "North East" 
                    },
                   
                    new Client
                    {
                        ClientName = "Customer 2",
                        Region = "South"
                    },
                    new Client
                    {
                        ClientName = "Customer 3",
                        Region = "North Central"
                    },
                    new Client
                    {
                        ClientName = "Customer 4",
                        Region = "West"
                    },
                    new Client
                    {
                        ClientName = "Customer 5",
                        Region = "North East"
                    },

                    new Client
                    {
                        ClientName = "Customer 6",
                        Region = "South"
                    },
                    new Client
                    {
                        ClientName = "Customer 7",
                        Region = "North Central"
                    },
                    new Client
                    {
                        ClientName = "Customer 8",
                        Region = "West"
                    },
                    new Client
                    {
                        ClientName = "Customer 9",
                        Region = "West"
                    },
                    new Client
                    {
                        ClientName = "Customer 10",
                        Region = "South"
                    }
                );
                context.SaveChanges();
            }// end if
        }//end static

    }// end class
}// end namespace

using Group1_Assn4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;


namespace Group1_Assn4.Controllers
{
    public class ProjectController : Controller
    {
        private IProjectRepository repository;
        public ProjectController(IProjectRepository repo)
        {
            repository = repo;
        }
         public ViewResult List() => View(repository.Projects.Include(p=>p.Client));

   

        public ViewResult Question3()
        {
            ViewData["LINQ"] = "repository.Projects.Include(p=>p.Client).GroupBy(p => p.Client.ClientName)" +
                                ".OrderByDescending(p=>p.Count()).Select(p=>p.First())" +
                                ".Where(p => p.KickOffDate.Year < DateTime.Today.Year && p.DeliveryDate.Year > DateTime.Today.Year)" +
                                ".Take(3); ";
            //3.	Which are the top 3 clients with most number of projects this year? 

            var Quest3 = repository.Projects.Include(p=>p.Client)
                                    .GroupBy(p => p.Client.ClientName) 
                                    .OrderByDescending(p=>p.Count())
                                    .Select(p=>p.First())
                                    .Where(p => p.KickOffDate.Year < DateTime.Today.Year && p.DeliveryDate.Year > DateTime.Today.Year)
                                    .Take(3);

            return View(Quest3.ToList());
        }// end of question 3
         

    }// end class
}// end namespace



//SELECT Top(4)   dbo.Clients.ClientName, (SUM(dbo.Projects.Revenue)   - SUM(dbo.ProjectResources.AllocatedHours* dbo.Resources.HourlyRate)) as PROFIT
//FROM            dbo.Clients INNER JOIN
//                    dbo.Projects ON dbo.Clients.ClientID = dbo.Projects.ClientID INNER JOIN
//                    dbo.ProjectResources ON dbo.Projects.ProjectID = dbo.ProjectResources.ProjectID INNER JOIN
//                    dbo.Resources ON dbo.ProjectResources.ResourceID = dbo.Resources.ResourceID
//GROUP BY dbo.Clients.ClientName , dbo.Projects.KickOffDate
//HAVING dbo.Projects.KickOffDate<getdate()
//ORDER BY(SUM(dbo.Projects.Revenue)   - SUM(dbo.ProjectResources.AllocatedHours* dbo.Resources.HourlyRate))  DESC
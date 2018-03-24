using Group1_Assn4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;


namespace Group1_Assn4.Controllers
{
    public class Q4Result
    {
        public string ClientName { get; set; }
        public decimal Revenue { get; set; }
    }
    public class ProjectController : Controller
    {
        private IProjectRepository repository;
        public ProjectController(IProjectRepository repo)
        {
            repository = repo;
        }
        public ViewResult List() => View(repository.Projects.Include(p=>p.Client));

        public ViewResult Question4()
        {
            ViewData["LINQ"] =
                "var Q4 = repository.Projects"
                + ".Include(p => p.Client)"
                + ".GroupBy(p => p.Client.ClientName)"
                + ".Select("
                + "g => new Q4Result"
                + "{ClientName = g.First().Client.ClientName,"
                + "Revenue = g.Sum(s => s.Revenue)"
                + "}).OrderBy(g => g.Revenue).Take(4);";
            //4. Who are the 4 most profitable clients till date?
            var Q4 = repository.Projects
                                   .Include(p => p.Client)
                                   .GroupBy(p => p.Client.ClientName)
                                   .Select(
                                       g => new Q4Result
                                       {
                                           ClientName = g.First().Client.ClientName,
                                           Revenue = g.Sum(s => s.Revenue)
                                       }).OrderBy(g => g.Revenue).Take(4);

             return View(Q4.ToList());
        }
        public ViewResult Question6()
        {
            ViewData["LINQ"] = "repository.Projects"
                + ".Include(p=>p.Client).GroupBy(p => p.Client.ClientName)"
                + ".OrderByDescending(p=>p.Count())"
                + ".Select(p=>p.First())"
                + ".Where(p => p.KickOffDate.Year < DateTime.Today.Year && p.DeliveryDate.Year > DateTime.Today.Year)"
                + ".Take(3); ";
            //6.	Which are the top 3 clients with most number of projects this year? 

            var Quest6 = repository.Projects.Include(p=>p.Client)
                                    .GroupBy(p => p.Client.ClientName) 
                                    .OrderByDescending(p=>p.Count())
                                    .Select(p=>p.First())
                                    .Where(p => p.KickOffDate.Year < DateTime.Today.Year && p.DeliveryDate.Year > DateTime.Today.Year)
                                    .Take(3);

            return View(Quest6.ToList());
        }// end of question 6
         
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
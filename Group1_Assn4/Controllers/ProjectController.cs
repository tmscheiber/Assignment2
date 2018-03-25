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

    public class Q6Result
    {
        public string ClientName { get; set; }
        public int ProjectCount { get; set; }
    }

    public class ProjectController : Controller
    {
        private IProjectRepository repository;
        public ProjectController(IProjectRepository repo)
        {
            repository = repo;
        }
        public ViewResult List() => View(repository.Projects.Include(p => p.Client));

        //public ViewResult Question4()
        //{
        //    ViewData["LINQ"] =
        //        "var revenue = repository.Projects^"
        //        + "_.Include(p => p.Client)^"
        //        + "_.GroupBy(p => p.Client.ClientName)^"
        //        + "_.Select(g => new Q4Result^"
        //        + "_{^"
        //        + "__ClientName = p.First().Client.ClientName,^"
        //        + "__Revenue = p.Sum(s => s.Revenue)^"
        //        + "_})^"
        //        + "_.OrderBy(p.C)^"
        //        + "_.Take(4);";
        //    //4. Who are the 4 most profitable clients till date?
        //    var ProjectRevenue = repository.Projects
        //                       .Include(p => p.Client)
        //                       .OrderBy(p => p.Client.ClientName)
        //                       .GroupBy(p => p.Client.ClientName)
        //                       .Select(p => new ProjectRevenue
        //                       {
        //                           ClientName = p.First().Client.ClientName,
        //        ProjectID = p.First().ProjectID,
        //        ProjectName = p.First().ProjectName,
        //                           Revenue = p.Sum(s => s.Revenue)
        //                       });
        //    //var ProjectCost = repository.
        //    return View(ProjectRevenue.ToList());
        //}
        public ViewResult Question6()
        {
            ViewData["LINQ"] = "repository.Projects^"
                + "_.Include(p=>p.Client).GroupBy(p => p.Client.ClientName)^"
                + "_.Where(p => p.KickOffDate.Year < DateTime.Today.Year && p.DeliveryDate.Year > DateTime.Today.Year)^"
                + "_.OrderByDescending(p=>p.Count())^"
                + "_.Take(3)^"
                + "_.Select(g => new Q6Result^"
                + "_{"
                + "__ClientName = g.First().Client.ClientName,^"
                + "__ProjectCount = g.Count()^"
                + "_});";
            //6.	Which are the top 3 clients with most number of projects this year? 

            var Quest6 = repository.Projects.Include(p => p.Client)
                                   .GroupBy(p => p.Client.ClientName)
                                   .Where(p => p.First().KickOffDate.Year < DateTime.Today.Year && p.First().DeliveryDate.Year >= DateTime.Today.Year)
                                   .OrderByDescending(p => p.Count())
                                   .Take(3)
                                   .Select(g => new Q6Result
                                   {
                                       ClientName = g.First().Client.ClientName,
                                       ProjectCount = g.Count()
                                   });

            return View(Quest6.ToList());
        }// end of question 6

    }// end class
}// end namespace
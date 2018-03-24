using System;
using System.Collections.Generic;
using System.Linq;
using System.Dynamic;
using System.Threading.Tasks;
using Group1_Assn4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Group1_Assn4.Controllers
{
    public class Q5Result
    {
        public string ProjectName { get; set; }
        public int ResourceCount { get; set; }
    }

    public class ProjectResourceController : Controller
    {

        private IProjectResourceRepository repository;
        public ProjectResourceController(IProjectResourceRepository repo)
        {
            repository = repo;
        }
        public ViewResult List() => View(repository.ProjectResources);


        public IActionResult Index()
        {
            return View();
        }

        public ViewResult Question5()
        {
            ViewData["LINQ"] =
                "var Q5 = repository.ProjectResources" +
                    ".Include(p => p.Project)" +
                    ".GroupBy(p => p.Project.ProjectName)" +
                    ".OrderByDescending(p => p.Count())" +
                    ".Take(4)" +
                    ".Select(g => new Q5Result" +
                "{ProjectName = g.First().Project.ProjectName," +
                "ResourceCount = g.Count()});";
            //5.	Which are the 4 projects which used the most number of people (resources)?  

            var Q5 = repository.ProjectResources
                               .Include(p => p.Project)
                               .GroupBy(p => p.Project.ProjectName)
                               .OrderByDescending(p => p.Count())
                               .Take(4)
                               .Select(g => new Q5Result
                               {
                                   ProjectName = g.First().Project.ProjectName,
                                   ResourceCount = g.Count()
                               });
            return View(Q5.ToList());
        }// end of question 5

        public ViewResult Question4()
        {
            ViewData["LINQ"] = "repository.ProjectResources.GroupBy(p => p.ResourceID).Where(p=>p.Count() >1).Select(p => p.First()).Count();";
            //4.    How many people are working on more than one projects?  ?  

            var Quest4 = repository.ProjectResources.GroupBy(p => p.ResourceID).Where(p => p.Count() > 1).Select(p => p.First()).Count().ToString();

            ViewData["Answer"] = Quest4.ToString() + " Resources";

            return View(repository.ProjectResources);
        }// end of question 4

        [HttpGet]
        public ViewResult Question7()
        {
            ViewData["LINQ"] =
                "<interim result = repository.ProjectResources"
                + ".Include(p => p.Resource)"
                + ".GroupBy(p => p.Resource.ResourceID)"
                + ".Where(p => p.Count() > 1);"
                + "ResourceCount = (interim result).Count();";
            //7.    How many people are working on more than one projects?

            var Quest7Detail = repository.ProjectResources
                                   .Include(p => p.Resource)
                                   .GroupBy(p => new { p.Resource.ResourceID })
                                   .Where(p => p.Count() > 1);
            dynamic expando = new ExpandoObject();
            var Quest7 = expando as IDictionary<string, object>;
            Quest7.Add("ResourceCount", Quest7Detail.Count());

            return View(Quest7);
        }// end of question 7

        public ViewResult Question9()
        {
            ViewData["LINQ"] =
                "repository.ProjectResources"
                + ".Include(p => p.Project)"
                + ".Include(p => p.Resource)"
                + ".Include(p => p.Project.Client)"
                + ".OrderBy(p => p.Project.Client.ClientName)"
                + ".OrderBy(p => p.Project.ProjectName)"
                + ".Where(p => p.Project.KickOffDate <= DateTime.Parse(\"1 / 1 / 2018\") && p.Project.DeliveryDate > DateTime.Today);";
            //9. List all the ongoing projects names along with their expected delivery date , resource allocations and client names?

            var Quest9 = repository.ProjectResources
                                   .Include(p => p.Project)
                                   .Include(p => p.Resource)
                                   .Include(p => p.Project.Client)
                                   .OrderBy(p => p.Project.Client.ClientName)
                                   .OrderBy(p => p.Project.ProjectName)
                                   .Where(p => p.Project.KickOffDate <= DateTime.Parse("1/1/2018") && p.Project.DeliveryDate > DateTime.Today);

            ViewData["Answer"] = Quest9.ToString() + " Resources";

            return View(Quest9.ToList());
        }// end of question 9


        public ViewResult Question10()
        {
            ViewData["LINQ"] = "repository.ProjectResources.Include(p=>p.Resource).GroupBy(p => p.ResourceID).Where(p => p.Count() > 10).Select(p => p.First());";
            //10.	Who are top 5 resources who have worked on more than 10 projects?   

            var Quest10 = repository.ProjectResources
                                  .Include(p => p.Resource)
                                  .GroupBy(p => p.ResourceID)
                                  .Where(p => p.Count() > 10)
                                  .Select(p => p.First());

            return View(Quest10.ToList());
        }// end of question 10


        public ViewResult Question13()
        {
            ViewData["LINQ"] = "repository.ProjectResources.Include(p => p.Resource).Include(p => p.Project.Client).Include(p => p.Project)" +
                                   @".Where(p => p.Resource.Role == ""Software Consultant"" && p.Project.Status != ""Not Started"")" +
                                   ".GroupBy(p => p.Project.ClientID)" +
                                   ".OrderByDescending(p => p.Count())" +
                                   ".Select(p => p.First()).Take(1); ";
            // 13.	List client with most number of resources working as Software Consultant in their ongoing projects? 

            var Quest13 = repository.ProjectResources
                                  .Include(p => p.Resource)
                                  .Include(p => p.Project.Client)
                                  .Include(p => p.Project)
                                  .Where(p => p.Resource.Role == "Software Consultant" && p.Project.Status != "Not Started")
                                  .GroupBy(p => p.Project.ClientID)
                                  .OrderByDescending(p => p.Count())
                                  .Select(p => p.First()).Take(1);

            return View(Quest13.ToList());
        }// end of question 13


    }// end class
}// end namespace
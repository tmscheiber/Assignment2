using System;
using System.Collections.Generic;
using System.Linq;
using System.Dynamic;
using System.Threading.Tasks;
using Group1_Assn4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Group1_Assn4.Controllers
{
    public class Q5Result
    {
        public string ProjectName { get; set; }
        public int ResourceCount { get; set; }
    }

    public class Q13Result
    {
        public string ClientName { get; set; }
        public int ResourceCount { get; set; }
    }

    public class ProjectCost
    {
        public int ProjectID { get; set; }
        public decimal Cost { get; set; }
    }

    public class ProjectRevenue
    {
        public string ClientName { get; set; }
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public decimal Revenue { get; set; }
    }

    public class ProjectProfit
    {
        public string ClientName { get; set; }
        [DataType(DataType.Currency)]
        public decimal Cost { get; set; }
        [DataType(DataType.Currency)]
        public decimal Revenue { get; set; }
        [DataType(DataType.Currency)]
        public decimal Profit { get; set; }
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

        public IEnumerable<ProjectCost> ProjectCosts()
        {
            ViewData["COST"] =
                "repository.ProjectResources^"
                + "_.Include(p => p.Resource)^"
                + "_.GroupBy(p => new { p.ProjectID, p.ProjectResourceID })^"
                + "_.Select(p => new ProjectCost {^"
                + "__ProjectID = p.First().ProjectID,^"
                + "__Cost = p.First().Resource.HourlyRate * p.First().AllocatedHours^"
                + "_});^";
            IEnumerable<ProjectCost> costs = repository.ProjectResources
                                                       .Include(p => p.Resource)
                                                       .GroupBy(p => new
                                                       {
                                                           p.ProjectID, p.ProjectResourceID
                                                       })
                                                       .Select(p => new ProjectCost
                                                       {
                                                           ProjectID = p.First().ProjectID,
                                                           Cost = p.First().Resource.HourlyRate * p.First().AllocatedHours
                                                       });
            return costs;
        }

        public IEnumerable<ProjectRevenue> ProjectRevenue()
        {
            ViewData["REVENUE"] =
                "repository.ProjectResources^"
                + "_.Include(p => p.Project.Client)^"
                + "_.Include(p => p.Project)^"
                + "_.GroupBy(p => new {^"
                + "__p.Project.Client.ClientName,^"
                + "__p.Project.ProjectID,^"
                + "__p.Project.ProjectName^"
                + "_})^"
                + "_.Select(p => new ProjectRevenue {^ "
                + "__ClientName = p.First().Project.Client.ClientName,^"
                + "__ProjectID = p.First().Project.ProjectID,^"
                + "__ProjectName = p.First().Project.ProjectName,^"
                + "__Revenue = p.First().Project.Revenue^"
                + "_});";
            IEnumerable<ProjectRevenue> revenue = repository.ProjectResources
                                                            .Include(p => p.Project.Client)
                                                            .Include(p => p.Project)
                                                            .GroupBy(p => new
                                                            {
                                                                p.Project.Client.ClientName,
                                                                p.Project.ProjectID,
                                                                p.Project.ProjectName
                                                            })
                                                            .Select(p => new ProjectRevenue
                                                            {
                                                                ClientName = p.First().Project.Client.ClientName,
                                                                ProjectID = p.First().Project.ProjectID,
                                                                ProjectName = p.First().Project.ProjectName,
                                                                Revenue = p.First().Project.Revenue
                                                            });

            return revenue;
        }

        public ViewResult Question4()
        {

            //4. Who are the 4 most profitable clients till date?
            ViewData["PROFIT"] =
                "List<ProjectProfit> profits = new List<ProjectProfit>();^"
                + "_ProjectProfit profit = new ProjectProfit();^"
                + "_foreach (var project in revenue) {^ "
                + "__if (project.ClientName != profit.ClientName) {^"
                + "___profit = new ProjectProfit();^"
                + "___profit.ClientName = project.ClientName;^"
                + "___profit.Revenue = project.Revenue;^"
                + "___profits.Add(profit);^ "
                + "__}^ "
                + "__else { profit.Revenue += project.Revenue; }^"
                + "__foreach (ProjectCost cost in costs) {^ "
                + "___if (project.ProjectID == cost.ProjectID) {^"
                + "____profit.Cost += cost.Cost;^"
                + "___}^"
                + "__}^"
                + "__profit.Profit = profit.Revenue - profit.Cost;^"
                + "_}^"
                + "_var FilteredProfits = profits.OrderByDescending(p => p.Profit).Take(4);^";

            var revenue = ProjectRevenue();
            var costs = ProjectCosts();

            List<ProjectProfit> profits = new List<ProjectProfit>();
            ProjectProfit profit = new ProjectProfit(); ;
            foreach (var project in revenue)
            {
                if (project.ClientName != profit.ClientName)
                {
                    profit = new ProjectProfit();
                    profit.ClientName = project.ClientName;
                    profit.Revenue = project.Revenue;
                    profits.Add(profit);
                }
                else
                {
                    profit.Revenue += project.Revenue;
                }
                foreach (ProjectCost cost in costs)
                {
                    if (project.ProjectID == cost.ProjectID)
                    {
                        profit.Cost += cost.Cost;
                    }
                }
                profit.Profit = profit.Revenue - profit.Cost;

            }
            var FilteredProfits = profits.OrderByDescending(p => p.Profit).Take(4);

            return View(FilteredProfits.ToList());
        }
        public ViewResult Question5()
        {
            ViewData["LINQ"] =
                "repository.ProjectResources^"
                + "_.Include(p => p.Project)^"
                + "_.GroupBy(p => p.Project.ProjectName)^"
                + "_.OrderByDescending(p => p.Count())^"
                + "_.Take(4)^"
                + "_.Select(p => new Q5Result^"
                + "_{^"
                + "__ProjectName = p.First().Project.ProjectName,^"
                + "__ResourceCount = p.Count()^"
                + "_});";
            //5.	Which are the 4 projects which used the most number of people (resources)?  

            var Q5 = repository.ProjectResources
                               .Include(p => p.Project)
                               .GroupBy(p => p.Project.ProjectName)
                               .OrderByDescending(p => p.Count())
                               .Select(p => new Q5Result
                               {
                                   ProjectName = p.First().Project.ProjectName,
                                   ResourceCount = p.Count()
                               })
                               .Take(4);

            return View(Q5.ToList());
        }// end of question 5

        [HttpGet]
        public ViewResult Question7()
        {
            ViewData["LINQ"] =
                "var Quest7Detail = repository.ProjectResources^"
                + "_.Include(p => p.Resource)^"
                + "_.GroupBy(p => p.Resource.ResourceID)^"
                + "_.Where(p => p.Count() > 1)^^"
                + "ResourceCount = (interim result).Count();^^"
                + "dynamic expando = new ExpandoObject();^^"
                + "var Quest7 = expando as IDictionary<string, object>;^^"
                + "Quest7.Add(\"ResourceCount\", Quest7Detail.Count());";
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
                "repository.ProjectResources^"
                + "_.Include(p => p.Project)^"
                + "_.Include(p => p.Resource)^"
                + "_.Include(p => p.Project.Client)^"
                + "_.OrderBy(p => p.Project.Client.ClientName)^"
                + "_.OrderBy(p => p.Project.ProjectName)^"
                + "_.Where(p => p.Project.KickOffDate <= DateTime.Parse(\"1 / 1 / 2018\") && p.Project.DeliveryDate > DateTime.Today);";
            //9. List all the ongoing projects names along with their expected delivery date , resource allocations and client names?

            var Quest9 = repository.ProjectResources
                                   .Include(p => p.Project)
                                   .Include(p => p.Resource)
                                   .Include(p => p.Project.Client)
                                   .Where(p => p.Project.KickOffDate <= DateTime.Parse("1/1/2018") && p.Project.DeliveryDate > DateTime.Today)
                                   .OrderBy(p => p.Project.Client.ClientName)
                                   .OrderBy(p => p.Project.ProjectName);

            ViewData["Answer"] = Quest9.ToString() + " Resources";

            return View(Quest9.ToList());
        }// end of question 9


        public ViewResult Question10()
        {
            ViewData["LINQ"] = 
                "repository.ProjectResources^"
                + "_.Include(p=>p.Resource)^"
                + "_.GroupBy(p => p.ResourceID).Where(p => p.Count() > 10)^"
                + "_.Select(p => p.First());";
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
            ViewData["LINQ"] = "repository.ProjectxResources^"
                + "_.Include(p => p.Resource)^"
                + "_.Include(p => p.Project.Client)^"
                + "_.Include(p => p.Project)^"
                + "_.Where(p => p.Resource.Role == \"Software Consultant\" && p.Project.Status != \"Not Started\")^"
                + "_.GroupBy(p => p.Project.ClientID)^"
                + "_.OrderByDescending(p => p.Count())^"
                + "_.Take(1)^"
                + "_.Select(p => new Q13Result^"
                + "_{^"
                + "__ClientName = p.First().Project.Client.ClientName,^"
                + "__ResourceCount = p.Count()^"
                + "_});";
            // 13.	List client with most number of resources working as Software Consultant in their ongoing projects? 

            var Quest13 = repository.ProjectResources
                                    .Include(p => p.Project)
                                    .Include(p => p.Resource)
                                    .Include(p => p.Project.Client)
                                    .Where(p => p.Resource.Role == "Software Consultant" && p.Project.Status != "Not Started")
                                    .GroupBy(p => p.Project.Client.ClientName)
                                    .OrderByDescending(p => p.Count())
                                    .Select(p => new Q13Result
                                    {
                                        ClientName = p.First().Project.Client.ClientName,
                                        ResourceCount = p.Count()
                                    })
                                    .Take(1);

            return View(Quest13.ToList());
        }// end of question 13
    }// end class
}// end namespace
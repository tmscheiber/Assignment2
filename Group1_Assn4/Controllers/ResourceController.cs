using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Group1_Assn4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Group1_Assn4.Controllers
{
    public class Q12Result
    {
        public string ClientName { get; set; }
        public int ResourceCount { get; set; }
    }
    public class ResourceController : Controller
    {
        private IResourceRepository repository;
        public ResourceController(IResourceRepository repo)
        {
            repository = repo;
        }
        public ViewResult List() => View(repository.Resources);



        public IActionResult Index()
        {
            return View();
        }

        public ViewResult Question8()
        {
            ViewData["LINQ"] = "repository.Resources.^"
                + "_.GroupBy(p => p.Role)^"
                + "_.Where(p => p.Count() > 1)^"
                + "_.Select(p => p.First());";
            //8.    List down all the roles available?   

            var Quest = repository.Resources.GroupBy(p => p.Role).Where(p => p.Count() > 1).Select(p => p.First());



            return View(Quest.ToList());
        }// end of question 8


        public ViewResult Question12()
        {
            ViewData["LINQ"] = @"repository.Resources^"
                + "_.Where(p => p.Role ==  \"Lead\" || p.Role == \"Senior Manager\" || p.Role == \"Manager\")^"
                + "_.OrderByDescending(p => p.ServiceYears);";
            //10.	List out resources with role as Lead or Manager or Senior Manager in descending order of number of years worked for the company?  

            var Quest = repository.Resources
                                  .Where(p => p.Role == "Lead" || p.Role == "Senior Manager" || p.Role == "Manager")
                                  .OrderByDescending(p => p.ServiceYears);
            
            return View(Quest.ToList());
        }// end of question 12














    }
}
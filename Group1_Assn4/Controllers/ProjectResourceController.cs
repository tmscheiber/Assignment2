using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Group1_Assn4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Group1_Assn4.Controllers
{
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

        public ViewResult Question2()
        {
            ViewData["LINQ"] = "repository.ProjectResources.Include(p=>p.Project).GroupBy(p => p.Project.ProjectName).OrderByDescending(p=>p.Count())" +
                                ".Select(p=>p.First()).Take(4); ";
            //2.	Which are the 4 projects which used the most number of people (resources)?  

            var Quest2 = repository.ProjectResources.Include(p => p.Project)
                                    .GroupBy(p => p.Project.ProjectName)
                                    .OrderByDescending(p => p.Count())
                                    .Select(p => p.First())
                                    .Take(4);

            return View(Quest2.ToList());
        }// end of question 2

        public ViewResult Question4()
        {
            ViewData["LINQ"] = "repository.ProjectResources.GroupBy(p => p.ResourceID).Where(p=>p.Count() >1).Select(p => p.First()).Count();";
            //4.	How many people are working on more than one projects?  ?  

            var Quest4 = repository.ProjectResources.GroupBy(p => p.ResourceID).Where(p=>p.Count() >1).Select(p => p.First()).Count().ToString();

            ViewData["Answer"] = Quest4.ToString() + " Resources";

            return View(repository.ProjectResources);
        }// end of question 4

        public ViewResult Question7()
        {
            ViewData["LINQ"] = "repository.ProjectResources.Include(p=>p.Resource).GroupBy(p => p.ResourceID).Where(p => p.Count() > 10).Select(p => p.First());";
            //7.	Who are top 5 resources who have worked on more than 10 projects?   

            var Quest = repository.ProjectResources.Include(p=>p.Resource).GroupBy(p => p.ResourceID).Where(p => p.Count() > 10).Select(p => p.First());

             

            return View(Quest.ToList());
        }// end of question 7


        public ViewResult Question10()
        {
            ViewData["LINQ"] = "repository.ProjectResources.Include(p => p.Resource).Include(p => p.Project.Client).Include(p => p.Project)" +
                                   @".Where(p => p.Resource.Role == ""Software Consultant"" && p.Project.Status != ""Not Started"")" +
                                   ".GroupBy(p => p.Project.ClientID)" +
                                   ".OrderByDescending(p => p.Count())" +
                                   ".Select(p => p.First()).Take(1); ";
            // 10.	List client with most number of resources working as Software Consultant in their ongoing projects? 

            var Quest = repository.ProjectResources.Include(p => p.Resource).Include(p => p.Project.Client).Include(p => p.Project)
                                    .Where(p => p.Resource.Role == "Software Consultant" && p.Project.Status != "Not Started")
                                   .GroupBy(p => p.Project.ClientID)
                                   .OrderByDescending(p => p.Count())
                                   .Select(p => p.First()).Take(1);


            return View(Quest.ToList());
        }// end of question 10


    }// end class
}// end namespace
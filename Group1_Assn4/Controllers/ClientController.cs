using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Group1_Assn4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Group1_Assn4.Controllers
{
    public class ClientController : Controller
    {
        private IClientRepository repository;
        public ClientController(IClientRepository repo)
        {
            repository = repo;
        }
        public ViewResult List() => View(repository.Clients);
        public IActionResult Index()
        {
            return View();
        }
        public ViewResult Question8()
        {
            ViewData["LINQ"] = @"repository.Clients.Where(p => p.Region == ""South"").GroupBy(p => p.ClientName).Select(p => p.First());";
           // 8.List out all the clients along with details which are in South American states like Texas, Florida, etc?

          var Quest = repository.Clients.Where(p => p.Region == "South").GroupBy(p => p.ClientName).Select(p => p.First());



            return View(Quest.ToList());
        }// end of question 8

    


    }
}
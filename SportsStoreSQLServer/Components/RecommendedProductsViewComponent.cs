using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using SportsStoreSQLServer.Models;


namespace SportsStoreSQLServer.Components
{
    public class RecommendedProductsViewComponent : ViewComponent
    {
        private IProductRepository repository;
        public RecommendedProductsViewComponent(IProductRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke(int productID, string returnURL  )
        {
          

             ViewData["ReturnURL"] = returnURL;


          // need to add the LINQ query that Blanca is working on
            //http://www.entityframeworktutorial.net/efcore/working-with-stored-procedure-in-ef-core.aspx
            // needs to be the full product entity as a return to populate each card item with title, description. price and id
            // Added this line as it should run sproc, but the current one will need to be altered.
            return View(repository.Products.FromSql($"ShowRecommendation {productID}").ToList());

            // initial one used for testing before sproc was created
            // return View(repository.Products.Take(4).ToList());
        }
    }// end class
}// end namespace
using Microsoft.AspNetCore.Mvc;

namespace SportsStoreSQLServer.Controllers
{
    public class ErrorController : Controller
    {
        public ViewResult Error() => View();
    }
}
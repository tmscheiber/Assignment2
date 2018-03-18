using Microsoft.AspNetCore.Mvc;

namespace TMSSportsStore.Controllers
{
    public class ErrorController : Controller
    {
        public ViewResult Error() => View();
    }
}
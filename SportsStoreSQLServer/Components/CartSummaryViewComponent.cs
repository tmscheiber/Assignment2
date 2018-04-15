using Microsoft.AspNetCore.Mvc;
using SportsStoreSQLServer.Models;

namespace SportsStoreSQLServer.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        public CartSummaryViewComponent(Cart cartService)
        {
            cart = cartService;
        }
        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
        private Cart cart;
    }
}
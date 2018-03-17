using Microsoft.AspNetCore.Mvc;
using TMSSportsStore.Models;

namespace TMSSportsStore.Components
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
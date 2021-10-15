using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEB_953504_KARMYZOW.Extensions;

public class CartViewComponent : ViewComponent
{
    private Cart _cart;
    public CartViewComponent(Cart cart)
    {
        _cart = cart;
    }
    public IViewComponentResult Invoke()
    {
        var cart = HttpContext.Session.Get<Cart>("cart");
        return View(cart);
    }
}

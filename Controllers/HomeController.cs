using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(User user)
    {
        if (user.Age < 16)
        {
            return View("UnderAge");
        }
        else
        {
            return RedirectToAction("Order", "Home");
        }
    }

    [HttpGet]
    public IActionResult Order()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Order(int quantity)
    {
        return RedirectToAction("ProductForm", "Home", new { quantity = quantity });
    }

    [HttpGet]
    public IActionResult ProductForm(int quantity)
    {
        ViewBag.Quantity = quantity;
        return View();
    }

    [HttpPost]
    public IActionResult ProductForm(List<Product> products)
    {
        return View("Summary", products);
    }
}
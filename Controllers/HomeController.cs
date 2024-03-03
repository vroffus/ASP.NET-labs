using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(string value, DateTime expiryDate)
    {
        CookieOptions options = new CookieOptions();
        options.Expires = expiryDate;

        Response.Cookies.Append("MyCookie", value, options);

        return RedirectToAction("CheckCookie");
    }

    public IActionResult CheckCookie()
    {
       // string cookieValue = Request.Cookies["MyCookie"];

        string cookieValue = null;
        var length = cookieValue.Length;

        if (cookieValue == null)
        {
            return Content("No cookie found.");
        }
        else
        {
            return Content($"Cookie value: {cookieValue}");
        }
    }
}
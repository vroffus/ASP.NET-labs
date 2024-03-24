using Microsoft.AspNetCore.Mvc;
using Lab8.Models;
using System;
using System.Collections.Generic;

namespace Lab8.Controllers
{
    public class ProductController : Controller
    {
        public static List<Product> products = new List<Product>
        {
            new Product { ID = 1, Name = "Product 1", Price = 199, CreatedDate = DateTime.Now.AddDays(-10) },
                new Product { ID = 2, Name = "Product 2", Price = 299, CreatedDate = DateTime.Now.AddDays(-5) },
                new Product { ID = 3, Name = "Product 3", Price = 399, CreatedDate = DateTime.Now }
        };
        public IActionResult List()
        {
            return View(products);
        }

        public IActionResult Table()
        {
            return View(products);
        }
    }
}

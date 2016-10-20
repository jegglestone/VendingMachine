using System.Web.Mvc;

namespace Vendor.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public class HomeController : Controller
    {
        private readonly VendingOptions vendingOptions;

        public HomeController()
        {
            vendingOptions = new VendingOptions
            {
                Products = new List<Product>
                {
                    new Product {Name = "Cola", Price = 1},
                    new Product {Name = "Candy", Price = 0.65},
                    new Product {Name = "Chips", Price = 0.5}
                },
                AvailableChange = new List<double> { 1, 0.5, 0.2, 0.1, 0.05 }
            };
        }

        public ActionResult Index()
        {

            return View(vendingOptions);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult BuyProduct(List<double> checkChange, string submit)
        {
            var sum = (int)checkChange.Sum();

            var selectedProductPrice = (int)vendingOptions.Products.First(x => x.Name == submit).Price;

            if (selectedProductPrice == sum)
            {
                ViewBag.Message = "Thank you!";
            }
            else if (sum > selectedProductPrice)
            {
                ViewBag.Message = "Thank you. Your change is £" + (sum - selectedProductPrice);
            }
            else
            {
                ViewBag.Message = "INSERT COINS";
            }
            return View("ThankYou");
        }
    }
}
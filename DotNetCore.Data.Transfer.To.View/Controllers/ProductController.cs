using DotNetCore.Data.Transfer.To.View.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DotNetCore.Data.Transfer.To.View.Controllers
{
    public class ProductController : Controller
    {
        public List<Product> GetProductsList
        {
            get
            {
                List<Product> products = new List<Product>();
                products.Add(new Product { Id = 1, ProductName = "Elma", Price = 21, Stock = 10 });
                products.Add(new Product { Id = 2, ProductName = "Armut", Price = 22, Stock = 10 });
                products.Add(new Product { Id = 3, ProductName = "Karpuz", Price = 23, Stock = 10 });
                products.Add(new Product { Id = 4, ProductName = "Kavun", Price = 24, Stock = 10 });

                return products;

            }

        }
        public IActionResult List()
        {
            TempData["ProductList"] = JsonConvert.SerializeObject(GetProductsList);
            ViewBag.Products = JsonConvert.SerializeObject(GetProductsList);
            ViewData["ProductList"] = JsonConvert.SerializeObject(GetProductsList);

            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            var tempDataVeri = TempData["ProductList"];
            var viewBagDataVeri = ViewBag.ProductsList;
            var viewDataVeri = ViewData["ProductList"];
            ViewBag.UrunListesi = JsonConvert.DeserializeObject<List<Product>>(tempDataVeri.ToString());
            return View();
        }
    }
}

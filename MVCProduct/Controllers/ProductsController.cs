using MVCProduct.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProduct.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        
        public ActionResult Index()
        {
            var product = GetProductsDeatils();


            return View(product);
        }


        public IEnumerable<Product> GetProductsDeatils()
        {
            return new List<Product>
            {
                new Product{ProductId=101 ,ProductName="Ac",Rate=45000},
                new Product{ProductId=102 ,ProductName="Mobile",Rate=38000},
                new Product{ProductId=103 ,ProductName="Bike",Rate=94000}
            };
        }
        public ActionResult Deatils(int id)
        {
            var product = GetProductsDeatils().SingleOrDefault(c => c.ProductId == id);
            if (product == null)
                return HttpNotFound();
            return View(product);
        }
    }
}
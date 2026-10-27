using BAITHUCHANHSO2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace BAITHUCHANHSO2.Controllers
{
    public class ProductController : Controller
    {
        public static List<Models.Product> products = new List<Models.Product>()
        {
            new Models.Product{Id=1, Name="nhi ngố ", Price=1000 , Description="Ngonhi description 1"},
            new Models.Product{Id=2, Name="Hòa nổ ", Price=500, Description="Hòa nổ description 2"},
            new Models.Product{Id=3, Name="Nam lọ", Price=800, Description="Nam lọ description 3"},
        };
        // GET: ProductController
        [HttpGet]
        public ActionResult Index()
        {
            return View(products);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var product = products.FirstOrDefault(c => c.Id == id);
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.Product product)
        {
            product.Id = products.Count + 1;
            products.Add(product);
            return RedirectToAction(nameof(Index));

        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var product = products.FirstOrDefault(c => c.Id == id);
            if (product == null) 
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            var editProduct = products.FirstOrDefault(c => c.Id == product.Id);
            if (editProduct == null)
            {
                return NotFound();
            }
            editProduct.Name = product.Name;
            editProduct.Price = product.Price;
            editProduct.Description = product.Description;
            editProduct.CategoryId = product.CategoryId;
            editProduct.Category = product.Category;
            return RedirectToAction(nameof(Index));
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(c => c.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var product = products.FirstOrDefault(c => c.Id == id);
            if (product == null)
            {
                return NotFound();
            } 
            products.Remove(product);
            return RedirectToAction(nameof(Index));

        }
    }
}

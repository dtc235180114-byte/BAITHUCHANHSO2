using BAITHUCHANHSO2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BAITHUCHANHSO2.Models;

namespace BAITHUCHANHSO2.Controllers
{
    public class CategoryController : Controller
    {
        // gia lap csdl 
        public static List<Models.Category> categories = new List<Models.Category>()
        {
            new Models.Category{Id=1, Name="Laptop 1"},
            new Models.Category{Id=2, Name="Phone 2"},
            new Models.Category{Id=3, Name="Tablet 3"},
        };
        // GET: CategoryController
        [HttpGet]
        public ActionResult Index()
        {
            // chuyen giu lieu tu controller sang view thong qua ViewBag
            return View(categories);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            var category = categories.FirstOrDefault(c => c.Id == id);

            return View();
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            category.Id = categories.Count + 1;
            categories.Add(category);
            return RedirectToAction(nameof(Index));
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var EditCategory = categories.FirstOrDefault(c => c.Id == id);
            if (EditCategory == null)
            {
                return NotFound();
            }
            return View(EditCategory);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            var existingCategory = categories.FirstOrDefault(c => c.Id == category.Id);
            if (existingCategory == null)
            {
                return NotFound();
            }

            existingCategory.Name = category.Name;

            return RedirectToAction(nameof(Index));
        }


        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var category = categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);

        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var category = categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            categories.Remove(category);
            return RedirectToAction(nameof(Index));
        }
    }
}



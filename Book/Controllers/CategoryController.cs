using Book.DataAccess.Data;
using Book.Models;
using Microsoft.AspNetCore.Mvc;

namespace Book.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _db;
        public CategoryController(AppDbContext db)
        {
                _db = db;
        }
        public IActionResult Index()
        {
            List<Category> categoriesList = _db.categories.ToList();
            return View(categoriesList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if(category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Category Name should not match Display Order");
            }
            if (ModelState.IsValid)
            {
                _db.categories.Add(category);
                _db.SaveChanges();
                TempData["success"] = "Category added sucessfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? category = _db.categories.Find(id);
            if(category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _db.categories.Update(category);
                _db.SaveChanges();
                TempData["success"] = "Category updated sucessfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? category = _db.categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? category = _db.categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            _db.categories.Remove(category);
            _db.SaveChanges();
            TempData["success"] = "Category delete sucessfully";
            return RedirectToAction("Index");
        }

    }
}

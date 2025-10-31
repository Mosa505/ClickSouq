using BookNest.DataAccess;
using BookNest.DataAccess.Repository.IRepository;
using BookNest.Models;
using BookNest.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookNest.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _UnitDb;

        public CategoryController(IUnitOfWork UnitDb)
        {
            _UnitDb = UnitDb;
        }
        public IActionResult Index()
        {
            var categories = _UnitDb.Category.GetAll();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category Obj)
        {
            if (Obj.Name == Obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The Display Order Cannot exactly match the Name. ");
            }
            if (ModelState.IsValid)
            {
                _UnitDb.Category.Add(Obj);
                _UnitDb.Save();
                TempData["success"] = "Category Created successfully";
                return RedirectToAction("Index");
            }
           
            return View(Obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _UnitDb.Category.Get(e=> e.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category Obj)
        {
            if (ModelState.IsValid)
            {
                _UnitDb.Category.Update(Obj);
                _UnitDb.Save(); 
                TempData["success"] = "Category Edit successfully";
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
            var category = _UnitDb.Category.Get(e => e.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var category = _UnitDb.Category.Get(e => e.Id == id);

            if (category == null)
                return NotFound();

            _UnitDb.Category.Remove(category);
            _UnitDb.Save();
            TempData["success"] = "Category Delete successfully";
            return RedirectToAction("Index");

        }


    }
}

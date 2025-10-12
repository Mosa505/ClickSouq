using ClickSouq.Data;
using ClickSouq.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClickSouq.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var categories = _context.categories.ToList();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category Obj)
        {
            if (Obj.Name == Obj.DisplayOrder.ToString()) 
            {
                ModelState.AddModelError("Name","The Display Order Cannot exactly match the Name. ");
            }
            if (ModelState.IsValid)
            {
                _context.categories.Add(Obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Obj);
        }
    }
}

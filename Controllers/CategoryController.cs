using ClickSouq.Data;
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
    }
}

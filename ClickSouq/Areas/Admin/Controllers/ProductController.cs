using BookNest.DataAccess.Repository.IRepository;
using BookNest.Models;
using BookNest.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookNest.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var Products = _unitOfWork.Product.GetAll();
            return View(Products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ProductViewModel productVM = new ProductViewModel()
            {
                Product = new Product(),
                CategoryList = _unitOfWork.Category.GetAll().Select(e =>
                new SelectListItem
                {
                    Text = e.Name,
                    Value = e.Id.ToString()
                }
                )

            };
            return View(productVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductViewModel Obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(Obj.Product);
                _unitOfWork.Save();
                TempData["success"] = "Product Created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                Obj.CategoryList = _unitOfWork.Category.GetAll().Select(e =>
                     new SelectListItem
                     {
                         Text = e.Name,
                         Value = e.Id.ToString()
                     }

                    );
                return View(Obj);
            }

        }


        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var product = _unitOfWork.Product.Get(e => e.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product Obj)
        {

            if (ModelState.IsValid)
            {

                _unitOfWork.Product.Update(Obj);
                _unitOfWork.Save();
                TempData["success"] = "Product Edit successfully";
                return RedirectToAction("Index");
            }

            return View(Obj);

        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var Product = _unitOfWork.Product.Get(e => e.Id == id);
            if (Product == null)
            {
                return NotFound();
            }

            return View(Product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var Product = _unitOfWork.Product.Get(e => e.Id == id);

            if (Product == null)
                return NotFound();

            _unitOfWork.Product.Remove(Product);
            _unitOfWork.Save();
            TempData["success"] = "Product Delete successfully";
            return RedirectToAction("Index");

        }
    }
}

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
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var Products = _unitOfWork.Product.GetAll(IncludeProperties: "Category").ToList();
            return View(Products);
        }
        [HttpGet]
        public IActionResult Upsert(int? id)
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
            if (id == null || id == 0)
            {
                return View(productVM);
            }
            else
            {
                productVM.Product = _unitOfWork.Product.Get(e => e.Id == id);
                return View(productVM);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ProductViewModel Obj, IFormFile? file)
        {

            if (ModelState.IsValid)
            {
                string WWWRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {

                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(WWWRootPath, @"images/product");

                    if (!string.IsNullOrEmpty(Obj.Product.ImageURL))
                    {
                        //Delete Old Image 
                        string oldImage = Path.Combine(productPath, Path.GetFileName(Obj.Product.ImageURL));

                        if (System.IO.File.Exists(oldImage))
                        {
                            System.IO.File.Delete(oldImage);
                        }

                    }
                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    Obj.Product.ImageURL = "/images/product/" + fileName;
                }
                else
                {

                    ModelState.AddModelError("Product.ImageURL", "Please upload a product image.");
                    ProductViewModel productVM = new ProductViewModel()
                    {
                        Product = new Product(),
                        CategoryList = _unitOfWork.Category.GetAll().Select(e =>
                        new SelectListItem
                        {
                            Text = e.Name,
                            Value = e.Id.ToString()
                        })

                    };
                    return View(productVM);
                }

                if (Obj.Product.Id == 0)
                {
                    _unitOfWork.Product.Add(Obj.Product);
                    _unitOfWork.Save();
                    TempData["success"] = "Product Create successfully";
                }

                else
                {
                    _unitOfWork.Product.Update(Obj.Product);
                    _unitOfWork.Save();
                    TempData["success"] = "Product Update successfully";
                }


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

        #region API Call 
        [HttpGet]
        public IActionResult GetAll()
        {
            var product = _unitOfWork.Product.GetAll(IncludeProperties: "Category").ToList();
            return Json(new { data = product });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var productDelete = _unitOfWork.Product.Get(e => e.Id == id);
            if (productDelete == null)
            {
                return Json(new { success = false, massage = "Error While Deleting" });
            }
            // Delete Image
            string productPath = Path.Combine(_webHostEnvironment.WebRootPath, @"images/product");
            var oldImage = Path.Combine(productPath, Path.GetFileName(productDelete.ImageURL));
           
            if (System.IO.File.Exists(oldImage))
            {
                System.IO.File.Delete(oldImage);
            }
            //
            _unitOfWork.Product.Remove(productDelete);
            _unitOfWork.Save();

            return Json(new { success = true, massage = "Delete Successful" });
        }

        #endregion

    }
}

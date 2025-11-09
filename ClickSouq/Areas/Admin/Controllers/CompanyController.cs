using BookNest.DataAccess.Repository.IRepository;
using BookNest.Models;
using BookNest.Models.ViewModels;
using BookNest.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookNest.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Company)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var com = _unitOfWork.Company.GetAll();
            return View(com);

        }

        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            var Empty_company = new Company();
             
            if (id == null || id == 0)
            {
                return View(Empty_company);
            }
            else
            {var company = _unitOfWork.Product.Get(e => e.Id == id);
                return View(company);
            }

        }


        #region Call API
        [HttpGet]
        public IActionResult GetAll()
        {
            var AllCompany = _unitOfWork.Company.GetAll().ToList();
            return Json(new { data = AllCompany });
        } 
        #endregion
    }
}

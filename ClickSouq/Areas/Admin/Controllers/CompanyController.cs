using BookNest.DataAccess.Repository.IRepository;
using BookNest.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetAll()
        {
            var AllCompany = _unitOfWork.Company.GetAll().ToList();
            return Json(new { data = AllCompany });
        }
    }
}

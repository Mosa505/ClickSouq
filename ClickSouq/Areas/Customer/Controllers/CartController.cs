using BookNest.DataAccess.Repository.IRepository;
using BookNest.Models;
using BookNest.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookNest.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class CartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ShoppingCartVM ShoppingCartVM { get; set; }
        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var ClaimsIdentity = (ClaimsIdentity)User.Identity;
            var UserId = ClaimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            ShoppingCartVM = new()
            {
                shoppingCartsList = _unitOfWork.ShoppingCart.GetAll(e => e.ApplicationUserId == UserId
                , IncludeProperties: "Product"
                )
            };
            foreach (var cart in ShoppingCartVM.shoppingCartsList)
            {
                 cart.Price = GetPriceBaseOnQuantity(cart);
                ShoppingCartVM.OrderTotal += cart.Price * cart.Count;
            }
            return View(ShoppingCartVM);

        }

        public IActionResult Plus (int cartId ) {
            var CartFromDb = _unitOfWork.ShoppingCart.Get(e => e.Id == cartId);
            CartFromDb.Count += 1;
            _unitOfWork.ShoppingCart.Update(CartFromDb);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        
        }
        public IActionResult Minus(int cartId)
        {
            var CartFromDb = _unitOfWork.ShoppingCart.Get(e => e.Id == cartId);
            if (CartFromDb.Count <= 1)
            {
                _unitOfWork.ShoppingCart.Remove(CartFromDb);
            }
            else {
                CartFromDb.Count -= 1;
                _unitOfWork.ShoppingCart.Update(CartFromDb);
            }
            
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Remove(int cartId)
        {
            var CartFromDb = _unitOfWork.ShoppingCart.Get(e => e.Id == cartId);
            _unitOfWork.ShoppingCart.Remove(CartFromDb);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Summary()
        {

            return View();
        }
        public double GetPriceBaseOnQuantity(ShoppingCart shoppingCart)
        {
            if (shoppingCart.Count <= 50)
            {
                return shoppingCart.Product.Price;
            }
            else if (shoppingCart.Count <= 100)
            {
                return shoppingCart.Product.Price50;
            }
            else
            {
                return shoppingCart.Product.Price100;
            }
        }
    }
}

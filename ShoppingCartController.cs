using CarAndGo.Data.Interfaces;
using CarAndGo.Data.Models;
using CarAndGo.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CarAndGo.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ICarRepository _CarRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(ICarRepository CarRepository, ShoppingCart shoppingCart)
        {
            _CarRepository = CarRepository;
            _shoppingCart = shoppingCart;
        }

        [Authorize]
        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(shoppingCartViewModel);
        }

        [Authorize]
        public RedirectToActionResult AddToShoppingCart(int CarId)
        {
            var selectedCar = _CarRepository.Cars.FirstOrDefault(p => p.CarId == CarId);
            if (selectedCar != null)
            {
                _shoppingCart.AddToCart(selectedCar, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int CarId)
        {
            var selectedCar = _CarRepository.Cars.FirstOrDefault(p => p.CarId == CarId);
            if (selectedCar != null)
            {
                _shoppingCart.RemoveFromCart(selectedCar);
            }
            return RedirectToAction("Index");
        }

    }
}

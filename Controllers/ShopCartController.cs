using Microsoft.AspNetCore.Mvc;
using Shop.Interfaces;
using Shop.Models;
using Shop.Repository;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IAllCars _carRepository;
        private readonly ShopCart _shopCart;

        public ShopCartController(IAllCars carRepository, ShopCart shopCart)
        {
            _shopCart = shopCart;
            _carRepository = carRepository;
        }

        public ViewResult Index()
        {
            var items = _shopCart.GetShopItems();
            _shopCart.ShopCartItems = items;
            var obj = new ShopCartViewModel() { shopCart = _shopCart };
            return View(obj);
        }
        
        public ViewResult CarInCart()
        {
            return View();
        }

        public RedirectToActionResult AddToCart(int id) 
        {
            var item = _carRepository.Cars.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                _shopCart.AddToCart(item);
            }

            return RedirectToAction("Index");
        }

        public RedirectToActionResult DeleteCar(int carId)
        {
            _shopCart.RemoveFromCart(carId);
            return RedirectToAction("Index");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Shop.Data;
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
        private readonly AppDBContent _appDBContent;

        public ShopCartController(IAllCars carRepository, ShopCart shopCart, AppDBContent content)
        {
            _shopCart = shopCart;
            _carRepository = carRepository;
            _appDBContent = content;
        }

        public ViewResult Index()
        {
            var items = _shopCart.GetShopItems();
            _shopCart.ShopCartItems = items;
            _appDBContent.SaveChanges();
            var obj = new ShopCartViewModel() { ShopCart = _shopCart };
            return View(obj);
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

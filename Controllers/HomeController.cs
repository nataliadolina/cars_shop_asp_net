using Microsoft.AspNetCore.Mvc;
using Shop.Interfaces;
using Shop.Models;
using Shop.ViewModels;
using System.Diagnostics;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllCars _carRepository;
        private readonly ShopCart _shopCart;

        public HomeController(IAllCars carRepository, ShopCart shopCart)
        {
            _shopCart = shopCart;
            _carRepository = carRepository;
        }

        public ViewResult Index()
        {
            var homeCars = new HomeViewModel
            {
                FavouriteCars = _carRepository.FavCars,
            };
            return View(homeCars);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Shop.Interfaces;

namespace Shop.Controllers
{
    public class CarsController : Controller
    {
        private readonly IAllCars _allCars;
        private readonly ICarsCategory _allCategories;

        public CarsController(IAllCars allCars, ICarsCategory carsCategory)
        {
            _allCars = allCars;
            _allCategories = carsCategory;
        }

        public ViewResult List()
        {
            var cars = _allCars.Cars;
            return View(cars);
        }
    }
}

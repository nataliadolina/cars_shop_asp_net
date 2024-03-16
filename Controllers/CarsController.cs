using Microsoft.AspNetCore.Mvc;
using Shop.Interfaces;
using Shop.Models;
using Shop.ViewModels;

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

        [Route("Cars/List")]
        [Route("Cars/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Car> cars = null;
            string currentCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                cars = _allCars.Cars.OrderBy(i => i.Id);
            } else
            {
                if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(i => i.Category.CategoryName.Equals("Электромобили")).OrderBy(i => i.Id);
                }
                else if (string.Equals("fuel", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(i => i.Category.CategoryName.Equals("Классические автомобили")).OrderBy(i => i.Id);
                }
            }
            currentCategory = _category;
            CarsListViewModel carObj = new CarsListViewModel()
            {
                AllCars = cars,
                CurrentCategory = currentCategory,
            };

            ViewBag.Title = "Список всех автомобилей";

            return View(carObj);
        }
    }
}

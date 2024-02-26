using Microsoft.AspNetCore.Mvc;
using Shop.Interfaces;
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

        public ViewResult List()
        {
            ViewBag.Title = "Список всех автомобилей";
            CarsListViewModel model = new CarsListViewModel();
            model.AllCars = _allCars.Cars;
            model.CurrentCategory = "Автомобили";
            return View(model);
        }
    }
}

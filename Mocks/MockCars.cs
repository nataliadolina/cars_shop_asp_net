using Shop.Interfaces;
using Shop.Models;

namespace Shop.Mocks
{
    public class MockCars : IAllCars
    {
        private readonly ICarsCategory _carsCategory = new MockCategory();
        public IEnumerable<Car> Cars
        { 
            get
            {
                return new List<Car>
                {
                    new Car {Name="Tesla", ShortDesc= "", LongDesc="", Image = "", Price = 45000, IsFavourite = true, Available = true, Category = _carsCategory.AllCategories.First() }
                };
            }
        }
        public IEnumerable<Car> FavCars { get => Cars.Where(x => x.IsFavourite = true); }

        public Car GetObjectCar(int carId)
        {
            return Cars.Where(x => x.Id == carId).First();
        }
    }
}

using Shop.Data;
using Shop.Interfaces;
using Shop.Models;
using Microsoft.EntityFrameworkCore;

namespace Shop.Repository
{
    public class CarRepository : IAllCars
    {
        private readonly AppDBContent appDBContent;

        public CarRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Car> Cars => appDBContent.Car.Include(c => c.Category);

        public IEnumerable<Car> FavCars => appDBContent.Car.Where(x => x.IsFavourite).Include(c => c.Category);

        public Car GetObjectCar(int carId)
        {
            return appDBContent.Car.FirstOrDefault(p => p.Id == carId);
        }
    }
}

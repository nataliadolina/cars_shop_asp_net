using Shop.Models;

namespace Shop.Interfaces
{
    public interface IAllCars
    {
        public IEnumerable<Car>  Cars { get; }
        public IEnumerable<Car> FavCars { get; }
        public Car GetObjectCar(int carId);
    }
}

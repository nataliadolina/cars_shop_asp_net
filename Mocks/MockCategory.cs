using Shop.Interfaces;
using Shop.Models;

namespace Shop.Mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category> {
                    new Category { CategoryName = "Электромобили", Desc = "Современный вид транспорта" },
                    new Category { CategoryName = "Классические автомобили", Desc = "Машины с двигателем внутреннего сгорания" }
                };
            }
        }
    }
}

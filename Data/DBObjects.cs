using Shop.Interfaces;
using Shop.Models;
using System.Linq;

namespace Shop.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {
            if (!content.Category.Any())
            {
                content.Category.AddRange(Categories.Select(content => content.Value));
            }

            if (!content.Car.Any())
            {
                content.AddRange(
                    new List<Car>
                    {
                        new Car {Name="Tesla", ShortDesc= "Eco-friendly electric vehicles with exemplary technical characteristics. These cars travel up to 500 kilometers on a single charge and show good dynamics.", LongDesc="The Model S Ludicrous accelerates from 0 to 100 km/h in 3 seconds. Three models of electric vehicles are sold under the Tesla brand: S 3 X Y History. Elon Musk is the founder of the company and one of the creators of the PayPal payment system.", Image = "/img/tesla1.jpg", Price = 45000, IsFavourite = true, Available = true, Category = Categories["Электромобили"] },
                        new Car {Name="Nissan", ShortDesc="A pioneer in electric vehicles, Nissan has not only made them affordable but also more practical by investing in charging infrastructure and energy management.", LongDesc="Nissan is advancing initiatives that utilize mobility to realize a sustainable society. We'll continue to provide services that connect vehicles with people and society.", Image="/img/nissan.jpg", Price=30000, IsFavourite = true, Available = true, Category = Categories["Электромобили"] }
                    }
                );
            }

            content.SaveChanges();
        }

        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new List<Category> {
                        new Category { CategoryName = "Электромобили", Desc = "Современный вид транспорта" },
                        new Category { CategoryName = "Классические автомобили", Desc = "Машины с двигателем внутреннего сгорания" }
                    };
                    category = new Dictionary<string, Category>();
                    foreach (Category element in list)
                    {
                        category.Add(element.CategoryName, element);
                    }
                }
                return category;
            }
        }
    }
}

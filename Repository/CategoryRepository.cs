using Shop.Data;
using Shop.Interfaces;
using Shop.Models;

namespace Shop.Repository
{
    public class CategoryRepository : ICarsCategory
    {
        private readonly AppDBContent appDBContent;

        public CategoryRepository(AppDBContent appDbContent)
        {
            appDbContent = appDbContent;
        }
        public IEnumerable<Category> AllCategories => appDBContent.Category;
    }
}

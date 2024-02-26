namespace Shop.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Desc { get; set; }
        public List<Car> Cars { get; set; }
    }
}

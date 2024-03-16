namespace Shop.Models
{
    public class ShopCartItem
    {
        public int Id { get; set; }
        public Car Car { get; set; }
        public string ShopCartId { get; set; }
    }
}

using Shop.Data;
using Shop.Interfaces;
using Shop.Models;
using System.Drawing.Text;

namespace Shop.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDBContent appDBContent;
        private readonly ShopCart shopCart;

        public OrdersRepository(AppDBContent appDBContent, ShopCart shopCart)
        {
            this.appDBContent = appDBContent;
            this.shopCart = shopCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            appDBContent.Order.Add(order);

            var items = shopCart.ShopCartItems;
            foreach (var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    CarId = el.Car.Id,
                    OrderId = order.Id,
                    Price = el.Car.Price
                };
                appDBContent.orderDetail.Add(orderDetail);
            }
            appDBContent.SaveChanges();
        }
    }
}

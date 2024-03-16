using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using System.Diagnostics;

namespace Shop.Models
{
    public class ShopCart
    {
        private readonly AppDBContent appDBContent;

        public ShopCart(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public string Id { get; set; }
        public List<ShopCartItem> ShopCartItems { get; set; }

        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", shopCartId);
            return new ShopCart(context) { Id = shopCartId};
        }

        
        public void AddToCart(Car car)
        {
            this.appDBContent.ShopCartItem.Add(new ShopCartItem
            {
                ShopCartId = Id,
                Car = car,
            });

            appDBContent.SaveChanges();
        }

        public void RemoveFromCart(int carId)
        {
            appDBContent.ShopCartItem.Remove(appDBContent.ShopCartItem.Where(x => x.ShopCartId == Id && x.Car.Id == carId).FirstOrDefault());
            appDBContent.SaveChanges();
        }

        public List<ShopCartItem> GetShopItems()
        {
            return appDBContent.ShopCartItem.Where(c => c.ShopCartId == Id).Include(s => s.Car).ToList();
        }
    }
}

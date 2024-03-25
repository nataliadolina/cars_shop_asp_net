
using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Interfaces;
using Shop.Models;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {
        private readonly AppDBContent appDBContent;
        private readonly IAllOrders allOrders;
        private readonly ShopCart shopCart;

        public OrderController(AppDBContent appDBContent, IAllOrders allOrders, ShopCart shopCart)
        {
            this.allOrders = allOrders;
            this.shopCart = shopCart;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public RedirectToActionResult Checkout(Order order)
        {
            allOrders.CreateOrder(order);
            return RedirectToAction("Index", "Home");
        }
    }
}

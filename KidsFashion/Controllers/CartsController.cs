using KidsFashion.Data;
using KidsFashion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidsFashion.Controllers
{
    public class CartsController : Controller
    {
        // GET: Carts
        private KidsFashionContext db = new KidsFashionContext();
        private const string CartSessionName = "SHOPPING_CART";
        public ActionResult AddToCart(int productId, int quantity)
        {
            var existingProduct = db.Products.FirstOrDefault(p => p.Id == productId);
            if (existingProduct == null)
            {
                return new HttpNotFoundResult();
            }
            var cart = GetCart(); 
            cart.Add(existingProduct, quantity, false); 
            SetCart(cart); 

            return RedirectToAction("ShowCart", "Carts");
        }
        public ActionResult ShowCart()
        {
            return View("ShowCart", GetCart());
        }
        public ActionResult UpdateCart(int productId, int quantity)
        {
            var existingProduct = db.Products.FirstOrDefault(p => p.Id == productId);
            if (existingProduct == null)
            {
                return new HttpNotFoundResult();
            }
            var cart = GetCart();
            cart.Update(existingProduct, quantity);
            SetCart(cart);
            return View("ShowCart", GetCart());
        }
        public ActionResult gicungduoc(int? abc)
        {
            return View("ShowCart", GetCart());
        }
            public ActionResult RemoveCartItem(int productId)
        {
            var cart = GetCart();
            cart.Remove(productId);
            SetCart(cart);

            return View("ShowCart", GetCart());
        }

        public ActionResult RemoveAll()
        {
            ClearCart();
            return View("ShowCart", GetCart());
        }

        private Cart GetCart() 
        {
            Cart cart = new Cart();
            if (Session[CartSessionName] != null)
            {
                try
                { 
                    cart = Session[CartSessionName] as Cart;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            if (cart == null)
            {
                cart = new Cart();
            }
            return cart;
        }

        private void SetCart(Cart cart)
        {
            Session[CartSessionName] = cart;
        }

        private void ClearCart()
        {
            Session[CartSessionName] = null;
        }
    public ActionResult Index()
        {
            return View();
        }
    }
}
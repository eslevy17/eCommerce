using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using eCommerce.Models;

using Microsoft.EntityFrameworkCore;

namespace eCommerce.Controllers
{
    public class OrdersController : Controller
    {
        private eCommerceContext _context;
    
        public OrdersController(eCommerceContext context)
        {
            _context = context;
        }

        [HttpGet("orders/all")]
        public IActionResult AllOrders()
        {
            ViewData["Title"] = "Orders";
            return View("AllOrders");
        }

        [HttpGet("orders/create")]
        public IActionResult CreateOrder()
        {
            ViewData["Title"] = "Add Orders";
            ViewBag.Customers = _context.customers.ToList();
            return View("CreateOrder");
        }

        [HttpGet("orders/addtoorder")]
        public IActionResult AddToOrder(int customerid)
        {
            Customer CurrentCustomer = _context.customers.Where(c => c.id == customerid).First();
            ViewBag.CustomerName = CurrentCustomer.first_name + " " + CurrentCustomer.last_name;
            ViewBag.CustomerId = CurrentCustomer.id;
            ViewData["Title"] = "Add To Order";
            List<Product> AllProducts = _context.products.ToList();
            ViewBag.ThisCart = _context.cart_items.Where(c => c.customer_id == customerid).ToList();
            return View("AddToOrder", AllProducts);
        }

        [HttpPost("orders/addingtoorder")]
        public IActionResult AddingToOrder(int productid, int quantity, int customerid)
        {
            TempData["CustomerId"] = TempData["CustomerId"];
            List<Cart_Item> CartItems = _context.cart_items.Where(c => c.customer_id == customerid).Where(c => c.product_id == productid).ToList();
            if (CartItems.Count() > 0)
            {
                Cart_Item CurrentCartItem = CartItems.First();
                CurrentCartItem.product_quantity += quantity;
                _context.SaveChanges();
                return RedirectToAction("AllOrders");
            }
            else 
            {
                Cart_Item InstallingCartItem = new Cart_Item();
                InstallingCartItem.customer_id = customerid;
                InstallingCartItem.product_id = productid;
                InstallingCartItem.product_quantity = quantity;
                _context.cart_items.Add(InstallingCartItem);
                _context.SaveChanges();
                return RedirectToAction("AllOrders");
            }
        }

        [HttpGet("placeorder/{id}")]
        public IActionResult PlaceOrder(int id)
        {
            List<Cart_Item> CartItems = _context.cart_items.Where(c => c.customer_id == id).ToList();
            if (CartItems.Count() == 0)
            {
                return RedirectToAction("CustomerDetail", "Customers", new { id = id });
            }
            Order currentorder = new Order();
            currentorder.customer_id = id;
            _context.orders.Add(currentorder);
            _context.SaveChanges();

            foreach(Cart_Item cartitem in CartItems)
            {
                Order_Item orderitem = new Order_Item();
                orderitem.order_id = currentorder.id;
                orderitem.product_id = cartitem.product_id;
                orderitem.product_quantity = cartitem.product_quantity;
                _context.order_items.Add(orderitem);
                _context.Remove(cartitem);
                _context.SaveChanges();
            }
            return RedirectToAction("CustomerDetail", "Customers", new { id = id });
        }




        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

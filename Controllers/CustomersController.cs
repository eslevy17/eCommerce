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
    public class CustomersController : Controller
    {
        private eCommerceContext _context;
    
        public CustomersController(eCommerceContext context)
        {
            _context = context;
        }

        [HttpGet("customers/all")]
        public IActionResult AllCustomers()
        {
            List<Customer> AllCustomers = _context.customers.ToList();
            ViewData["Title"] = "Customers";
            return View("AllCustomers", AllCustomers);
        }

        [HttpGet("customers/add")]
        public IActionResult AddCustomer()
        {
            ViewData["Title"] = "Add Customer";
            return View("AddCustomer");
        }

        [HttpPost("customers/adding")]
        public IActionResult AddingCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.created_at = DateTime.Now;
                _context.customers.Add(customer);
                _context.SaveChanges();
                return RedirectToAction("AllCustomers");
            }
            else
            {
                return View("AddCustomer");
            }
        }

        [HttpGet("customers/{id}")]
        public IActionResult CustomerDetail(int id)
        {
            Customer customer = _context.customers.Where(c => c.id == id).First();
            customer.orders = _context.orders.Where(c => c.customer_id == id).Include(o => o.orders_and_items).ThenInclude(o => o.product).ToList();
            customer.cart_items = _context.cart_items.Where(c => c.customer_id == id).Include(p => p.product).ToList();
            return View("CustomerDetail", customer);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

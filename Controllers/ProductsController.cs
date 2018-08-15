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
    public class ProductsController : Controller
    {
        private eCommerceContext _context;
    
        public ProductsController(eCommerceContext context)
        {
            _context = context;
        }

        [HttpGet("products/all")]
        public IActionResult AllProducts()
        {
            ViewData["Title"] = "Products";
            List<Product> AllProducts = _context.products.ToList();
            return View("AllProducts", AllProducts);
        }

        [HttpGet("products/add")]
        public IActionResult AddProduct()
        {
            ViewData["Title"] = "Add Product";
            return View("AddProduct");
        }

        [HttpPost("products/adding")]
        public IActionResult AddingProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("AllProducts");
            }
            else
            {
                return View("AddProduct");
            }
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

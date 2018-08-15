using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Models
{
    public class Customer
    {
        public int id { get; set; }

        [Required(ErrorMessage = "First name is required and must be at least 2 letters.")]
        [MinLength(2, ErrorMessage = "First name is required and must be at least 2 letters.")]
        public string first_name { get; set; }

        [Required(ErrorMessage = "Last name is required and must be at least 2 letters.")]
        [MinLength(2, ErrorMessage = "Last name is required and must be at least 2 letters.")]
        public string last_name { get; set; }

        public DateTime created_at { get; set; }
        
        public List<Order> orders { get; set; }

        public List<Cart_Item> cart_items { get; set; }

        public Customer()
        {
            orders = new List<Order>();
            cart_items = new List<Cart_Item>();
        }
    }
}
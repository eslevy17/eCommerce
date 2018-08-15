using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Models
{
    public class Product
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Name is required and must be at least 3 characters.")]
        [MinLength(3, ErrorMessage = "Name is required and must be at least 3 characters.")]
        public string name { get; set; }

        [Required(ErrorMessage = "Image URL is required and must be at least 10 characters.")]
        [MinLength(10, ErrorMessage = "Image URL is required and must be at least 10 characters.")]
        public string image { get; set; }

        [Required(ErrorMessage = "Description is required and must be at least 5 characters.")]
        [MinLength(5, ErrorMessage = "Description is required and must be at least 5 characters.")]
        public string description { get; set; }

        [Required(ErrorMessage = "Price is required and must be greater than zero.")]
        [Range(0, 1000000000, ErrorMessage = "Price is required and must be greater than zero.")]
        public int price { get; set; }

        [Required(ErrorMessage = "Quantity is required and must be greater than or equal to zero.")]
        [Range(0, 1000000000, ErrorMessage = "Quantity is required and must be greater than or equal to zero.")]
        public int quantity { get; set; }

        public List<Order_Item> orders_and_items { get; set; }

        public Product()
        {
            orders_and_items = new List<Order_Item>();
        }
    }
}
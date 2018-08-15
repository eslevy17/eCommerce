using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Models
{
    public class Cart_Item
    {
        public int id { get; set; }

        [ForeignKey("customer")]
        public int customer_id { get; set; }
        public Customer customer { get; set; }

        [ForeignKey("product")]
        public int product_id { get; set; }
        public Product product { get; set; }
        
        public int product_quantity { get; set; }
    }
}
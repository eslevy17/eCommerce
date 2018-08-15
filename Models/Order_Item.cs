using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Models
{
    public class Order_Item
    {
        public int id { get; set; }

        [ForeignKey("order")]
        public int order_id { get; set; }
        public Order order { get; set; }

        [ForeignKey("product")]
        public int product_id { get; set; }
        public Product product { get; set; }

        public int product_quantity { get; set; }
    }
}
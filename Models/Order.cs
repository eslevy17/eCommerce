using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Models
{
    public class Order
    {
        public int id { get; set; }

        [ForeignKey("customer")]
        public int customer_id { get; set; }
        public Customer customer { get; set; }

        public List<Order_Item> orders_and_items { get; set; }

        public DateTime created_at { get; set; }

        public Order()
        {
            orders_and_items = new List<Order_Item>();
        }
    }
}
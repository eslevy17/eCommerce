using Microsoft.EntityFrameworkCore;

namespace eCommerce.Models
{
    public class eCommerceContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public eCommerceContext(DbContextOptions<eCommerceContext> options) : base(options) { }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Order_Item> order_items { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Cart_Item> cart_items { get; set; }
    }
}
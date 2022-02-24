using IZCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IZCommerce.Persistence
{
    public class IZCommerceDbContext : DbContext
    {
        public IZCommerceDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Shipper> Shippers { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Customer> Customers { get; set; }
    }
}

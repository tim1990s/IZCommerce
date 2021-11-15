using IZCommerce.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace IZCommerce.Infrastructure.DatabaseContext
{
    public class IZCommerceDBContext:DbContext
    {
        public IZCommerceDBContext(DbContextOptions options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}

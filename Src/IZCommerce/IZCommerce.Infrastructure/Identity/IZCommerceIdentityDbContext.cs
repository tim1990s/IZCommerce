using IZCommerce.Core.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IZCommerce.Infrastructure.Identity
{
    public class IZCommerceIdentityDbContext : IdentityDbContext<AppUser>
    {
        public IZCommerceIdentityDbContext(DbContextOptions<IZCommerceIdentityDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}

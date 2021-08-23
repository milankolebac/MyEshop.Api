using Microsoft.EntityFrameworkCore;

namespace MyEshop.Api.Models
{
    public class EshopContext : DbContext
    {
        public EshopContext(DbContextOptions<EshopContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}

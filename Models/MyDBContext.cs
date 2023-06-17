using Microsoft.EntityFrameworkCore;

namespace ProductAPI.Models
{
    public class MyDBContext:DbContext
    {
        public MyDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ProductTest> ProductTest { get; set; }
        //public DbSet<Category> Category { get; set; }
    }
}

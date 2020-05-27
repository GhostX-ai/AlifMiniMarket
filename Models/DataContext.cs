using Microsoft.EntityFrameworkCore;

namespace AlifAdminMiniMarketV2.Models
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
            
        }
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<ProductCategory>().HasData(new ProductCategory(){
                Id = 1,
                Category = "Фрукты"
            });
            model.Entity<ProductCategory>().HasData(new ProductCategory(){
                Id = 2,
                Category = "Овощи"
            });
            model.Entity<ProductCategory>().HasData(new ProductCategory(){
                Id = 3,
                Category = "Мясо"
            });
        }
    }
}
using ApiWithEF.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiWithEF.Persistance
{
    public class StoreDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<LastAction> LastActions { get; set; }
        

        public StoreDbContext(DbContextOptions<StoreDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Order>()
                .HasMany(o => o.Products)
                .WithMany(p => p.Orders)
                .UsingEntity<OrderProduct>(
                    order => order
                        .HasOne<Product>()
                        .WithMany(o => o.OrderProducts)
                        .HasForeignKey(p => p.ProductId),
                    product => product
                        .HasOne<Order>()
                        .WithMany(p => p.OrderProducts)
                        .HasForeignKey(o => o.OrderId)
                    );

            builder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User);
        }
    }
}

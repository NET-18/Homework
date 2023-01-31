using ApiWithEF.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiWithEF.Persistance
{
    public class StoreDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        public StoreDbContext(DbContextOptions<StoreDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders);

            builder.Entity<Order>().Property(o => o.TotalPrice).HasColumnType("decimal(18, 5)");

            builder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(18, 5)");
                
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
        }
    }
}

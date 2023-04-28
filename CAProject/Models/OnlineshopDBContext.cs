using Microsoft.EntityFrameworkCore;
using CAProject.Models;

namespace CAProject.Models
{
    public class OnlineshopDBContext : DbContext
    {

        public OnlineshopDBContext(DbContextOptions<OnlineshopDBContext> options):base(options) 
        { 
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderProduct>()
                .HasKey(op => new { op.ProductId, op.OrderId });
            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Product)
                .WithMany(p => p.OrderProducts)
                .HasForeignKey(op => op.ProductId);
            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Order)
                .WithMany(o => o.OrderProducts)
                .HasForeignKey(op => op.OrderId);

            modelBuilder.Entity<ActivationCode>()
               .HasKey(ac => new { ac.ProductId, ac.OrderId });
            modelBuilder.Entity<ActivationCode>()
                .HasOne(ac => ac.Product)
                .WithMany(p => p.ActivationCodes)
                .HasForeignKey(ac => ac.ProductId);
            modelBuilder.Entity<ActivationCode>()
                .HasOne(ac => ac.Order)
                .WithMany(o => o.ActivationCodes)
                .HasForeignKey(ac => ac.OrderId);


        }


        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<ActivationCode> ActivationCodes { get; set; }
        public DbSet<Cart> Carts { get; set; }


    }
}

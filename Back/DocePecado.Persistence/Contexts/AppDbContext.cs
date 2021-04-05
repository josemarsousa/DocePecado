using DocePecado.Domain;
using Microsoft.EntityFrameworkCore;

namespace DocePecado.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Define chave composta para OrderProduct
            modelBuilder.Entity<OrderProduct>()
                .HasKey(OP => new { OP.OrderId, OP.ProductId });

            //Deletar PedidoProdudo ao deletar o pedido
            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderProducts)
                .WithOne(op => op.Order)
                .OnDelete(DeleteBehavior.Cascade);
        }


    }
}

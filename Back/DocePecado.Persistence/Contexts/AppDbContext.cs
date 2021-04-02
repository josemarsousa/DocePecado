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

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //Define o int id como uma foreign key
        //    modelBuilder.Entity<OrderProduct>()
        //        .HasKey(OP => new { OP.Order, OP.Product });

        //    //Deletar PedidoProdudo ao deletar o pedido
        //    modelBuilder.Entity<Order>()
        //        .HasMany(o => o.OrderProducts)
        //        .WithOne(op => op.Order)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    //Deletar PedidoProdudo ao deletar o produto
        //    modelBuilder.Entity<Product>()
        //        .HasMany(p => p.OrderProducts)
        //        .WithOne(op => op.Product)
        //        .OnDelete(DeleteBehavior.Cascade);
        //}


    }
}

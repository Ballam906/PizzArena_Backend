using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PizzaArena_API.Models;
using PizzaArena_API.Services.OrderItemFolder.IOrderItemService;
namespace PizzaArena_API.Data
{
    public class PizzArenaDbContext : IdentityDbContext<User>
    {
        public PizzArenaDbContext(DbContextOptions<PizzArenaDbContext> options) : base(options)
        {
        }

        protected PizzArenaDbContext()
        {
        }

        public DbSet<User> users { get; set; } = null!;
        public DbSet<Product> products { get; set; } = null!;
        public DbSet<Order> orders { get; set; } = null!;
        public DbSet<Order_Item> order_items { get; set; } = null!;
        public DbSet<Category> categories { get; set; } = null!;
        public DbSet<ChefSpecial> chefSpecials { get; set; } = null!;
        public DbSet<GlobalSettings> globalSettings { get; set; } = null!;
        public DbSet<Restaurant> restaurants { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order_Item>()
                .HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.Item_Id)
                .OnDelete(DeleteBehavior.SetNull);

            base.OnModelCreating(modelBuilder);
        }

    }
}

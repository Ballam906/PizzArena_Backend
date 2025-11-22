using Microsoft.EntityFrameworkCore;

namespace PizzArena_API.Models
{
    public class PizzArenadbContext : DbContext
    {
        public PizzArenadbContext() { }

        public PizzArenadbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Termek> termekek { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=pizzarena;user=root;password=");
        }
    }
}

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
        public DbSet<Kategoria> kategoriak {  get; set; }


        public DbSet<Fiok> Fiokok { get; set; }
        public DbSet<Szerepkor> Szerepkorok { get; set; }

        public DbSet<Rendeles> Rendelesek { get; set; }
        public DbSet<Rendeles_Termek> Rendeles_Termek { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=pizzarena;user=root;password=");
        }
    }
}

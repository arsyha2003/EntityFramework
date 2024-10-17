using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Classes
{
    class Context : DbContext
    {
        private readonly IConfiguration configuration;
        public DbSet<Game> game { get; set; }
        public DbSet<GameMode> gameMode { get; set; }
        public DbSet<Countries> countries { get; set; }
        public DbSet<Company> companies { get; set; }
        public DbSet<StyleOfGame> styles { get; set; }
        public Context()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ModelGameShop;Trusted_Connection=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameMode>().HasMany(gm => gm.Game).WithOne(game => game.GameMode);
            modelBuilder.Entity<Game>().HasMany(game => game.Companies).WithMany(comp => comp.Games);
            modelBuilder.Entity<Company>().HasOne(comp => comp.Country).WithMany(country => country.Companies);
            modelBuilder.Entity<Game>().HasOne(style => style.Style).WithMany(game => game.Games);
            base.OnModelCreating(modelBuilder);
        }
    }
}

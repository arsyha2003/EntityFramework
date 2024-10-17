using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EntityFramework.Classes
{
    class Context : DbContext
    {
        private readonly IConfiguration configuration;
        public DbSet<Model> Game { get; set; }
        public Context()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ModelGameShop;Trusted_Connection=True");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ModelConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        //public void GroupData()
        //{
        //    var group = Game.GroupBy(x => x.NameOfGame).Select(x => new
        //    {
        //        Name = x.Key,
        //        Count = x.Count()
        //    });
        //    foreach (var g in group)
        //    {
        //        Console.WriteLine($"{g.Name} {g.Count}");
        //    }
        //}
    }
}

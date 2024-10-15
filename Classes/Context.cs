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
        DbSet<Model> game { get; set; }
        public Context()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connString = configuration.GetConnectionString("ModelDatabase");
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ModelGameShop;Trusted_Connection=True");
        }
    }
}

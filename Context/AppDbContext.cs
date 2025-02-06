using ApiCrud.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ApiCrud.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Definir as tabelas como DbSet
        public DbSet<Estudantes> Estudantes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudantes>().HasIndex(x => x.Email).IsUnique();
            base.OnModelCreating(modelBuilder);
        }
    }
}


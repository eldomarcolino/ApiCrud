using SistemaDeRecarga.Model;
using Microsoft.EntityFrameworkCore;

namespace SistemaDeRecarga.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Definir as tabelas como DbSet
        public DbSet<Curso> Curso { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Balance> Balance { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configuração de índices únicos
            modelBuilder.Entity<User>()
                .HasIndex(x => x.Email).IsUnique();
            modelBuilder.Entity<User>()
                .HasIndex(x => x.RegistrationNumber).IsUnique();
            modelBuilder.Entity<Curso>()
                .HasIndex(x => x.Name).IsUnique();


            //Configuração de relacionamento


            modelBuilder.Entity<User>()
                .HasOne(u => u.IdCourseNavigation)
                .WithMany(c => c.Users)
                .HasForeignKey(u => u.IdCourse);




            base.OnModelCreating(modelBuilder);
        }
    }
}
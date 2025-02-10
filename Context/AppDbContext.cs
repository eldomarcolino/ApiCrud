using ApiCrud.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ApiCrud.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Definir as tabelas como DbSet
        public DbSet<Students> Students { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<StudentsCurso> StudentsCursos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configuração de índices únicos
            modelBuilder.Entity<Students>()
                .HasIndex(x => x.Email).IsUnique();
            modelBuilder.Entity<Students>().HasIndex(x => x.RegistrationNumber).IsUnique();


            //Configuração de relacionamento
            modelBuilder.Entity<StudentsCurso>()
                .HasKey(x => new {x.StudentId, x.CourseId });

            modelBuilder.Entity<StudentsCurso>()
                .HasOne(x => x.Student)
                .WithMany(y => y.StudentsCursos)
                .HasForeignKey(x => x.StudentId);


            base.OnModelCreating(modelBuilder);
        }
    }
}
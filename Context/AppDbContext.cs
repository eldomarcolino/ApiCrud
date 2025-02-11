using ApiCrud.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Definir as tabelas como DbSet
        public DbSet<Students> Students { get; set; }
        public DbSet<Curso> Curso { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configuração de índices únicos
            modelBuilder.Entity<Students>()
                .HasIndex(x => x.Email).IsUnique();
            modelBuilder.Entity<Students>()
                .HasIndex(x => x.RegistrationNumber).IsUnique();
            modelBuilder.Entity<Curso>()
                .HasIndex(x => x.Name).IsUnique();


            //Configuração de relacionamento
            modelBuilder.Entity<Students>()
                .HasOne(s => s.Curso) //Um aluno pertence a um curso
                .WithMany(c => c.Students) //Um curso tem muitos alunos
                .HasForeignKey(s => s.CursoId); //Chave estrangeira no lado do aluno

            base.OnModelCreating(modelBuilder);
        }
    }
}
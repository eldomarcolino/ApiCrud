using SistemaDeRecarga.Model;
using Microsoft.EntityFrameworkCore;

namespace SistemaDeRecarga.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Definir as tabelas como DbSet
        public DbSet<Estudantes> Estudantes { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configuração de índices únicos
            modelBuilder.Entity<User>()
                .HasIndex(x => x.Email).IsUnique();
            modelBuilder.Entity<Estudantes>()
                .HasIndex(x => x.Email).IsUnique();
            modelBuilder.Entity<Estudantes>()
                .HasIndex(x => x.RegistrationNumber).IsUnique();
            modelBuilder.Entity<Curso>()
                .HasIndex(x => x.Name).IsUnique();


 //           //Configuração de relacionamento
 //           modelBuilder.Entity<Estudantes>()
 //               .HasOne(e => e.Curso) //Um aluno pertence a um curso
 //               .WithMany(c => c.Estudantes) //Um curso tem muitos alunos
 //               .HasForeignKey(e => e.CursoId); //Chave estrangeira no lado do aluno
 // por algum motivo, o relacionamento via cídgo nao estava funcionando, nao deixava salvar. tive que usar as migrations apenas para criaçao de tabelas e fazer as chaves estrangeiras na mao


            base.OnModelCreating(modelBuilder);
        }
    }
}
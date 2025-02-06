using ApiCrud.Context;
using ApiCrud.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.Repository
{
    public class EstudantesRepository : IEstudantesRepository
    {
        private readonly AppDbContext _context;

        public EstudantesRepository(AppDbContext context)
        {
            _context = context; 
        }

        public async Task<IEnumerable<Estudantes>> GetAllStudantAsync()
        {
            return await _context.Estudantes.ToListAsync();
        }

        public async Task<Estudantes> GetByIdAsync(int id)
        {
            return await _context.Estudantes.FindAsync(id);
        }

        public async Task CreateStudantAsync(Estudantes estudante)
        {
            await _context.Estudantes.AddAsync(estudante);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStudantAsync(Estudantes estudante)
        {
            _context.Estudantes.Update(estudante);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudantAsync(int id)
        {
            var studant = await _context.Estudantes.FindAsync(id);

            if (studant != null)
            {
                _context.Estudantes.Remove(studant);
                await _context.SaveChangesAsync();
            }
        }
    }
}

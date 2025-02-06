using ApiCrud.Context;
using ApiCrud.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.Repository
{
    public class StudentsRepository : IStudentsRepository
    {
        private readonly AppDbContext _context;

        public StudentsRepository(AppDbContext context)
        {
            _context = context; 
        }

        public async Task<IEnumerable<Students>> GetAllStudentAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Students> GetByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task CreateStudentAsync(Students estudante)
        {
            await _context.Students.AddAsync(estudante);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStudentAsync(Students estudante)
        {
            _context.Students.Update(estudante);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudentAsync(int id)
        {
            var studant = await _context.Students.FindAsync(id);

            if (studant != null)
            {
                _context.Students.Remove(studant);
                await _context.SaveChangesAsync();
            }
        }
    }
}

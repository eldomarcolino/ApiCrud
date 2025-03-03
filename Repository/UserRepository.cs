using Microsoft.EntityFrameworkCore;
using SistemaDeRecarga.Context;
using SistemaDeRecarga.Model;

namespace SistemaDeRecarga.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUserAsync()
        {
            return await _context.User.ToListAsync();
        }

        public async Task CreateUserAsync(User user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.User.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.User.FindAsync(id);

            if (user != null)
            {
                _context.User.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> GetLastIdAsync()
        {
            // Verificar se a tabela está vazia
            if (!await _context.User.AnyAsync())
            {
                return 0;
            }

            // Encontrar o maior ID existente no banco de dados
            return await _context.User.MaxAsync(x => x.Id);
        }

        public async Task<bool> EmailAndRegistrationNumberExistAsync(string email, string matricula) //Verifica a existencia de um email ou matrícula no banco
        {
            return await _context.User.AnyAsync(x => x.Email == email || x.RegistrationNumber == matricula);
        }
    }
}

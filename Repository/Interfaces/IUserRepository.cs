using SistemaDeRecarga.Model;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllUserAsync();
    Task CreateUserAsync(User user);
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(int id);
    Task<int> GetLastIdAsync();
    Task<bool> EmailAndRegistrationNumberExistAsync(string email, string matricula);
}
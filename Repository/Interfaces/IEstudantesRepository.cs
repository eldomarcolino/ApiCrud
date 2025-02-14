using SistemaDeRecarga.Model;

public interface IEstudantesRepository
{
    Task<IEnumerable<Estudantes>> GetAllEstudantesAsync();
    Task<Estudantes> GetEstudantesByIdAsync(int id);
    Task CreateEstudantesAsync(Estudantes estudante);
    Task UpdateEstudantesAsync(Estudantes estudante);
    Task DeleteEstudantesAsync(int id);
    Task<int> GetLastIdAsync();
    Task<bool> EmailAndRegistrationNumberExistAsync(string email, string matricula);
}

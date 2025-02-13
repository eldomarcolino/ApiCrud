using SistemaDeRecarga.Model;

public interface IEstudantesBusiness
{
    Task<IEnumerable<Estudantes>> GetAllEstudantesAsync();
    Task<Estudantes> GetEstudantesByIdAsync(int id);
    Task CreateEstudantesAsync(Estudantes estudante);
    Task UpdateEstudantesAsync(Estudantes estudante);
    Task DeleteEstudantesAsync(int id);
}
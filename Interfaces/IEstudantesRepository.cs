using ApiCrud.Model;

public interface IEstudantesRepository
{
    Task<IEnumerable<Estudantes>> GetAllStudantAsync();
    Task<Estudantes> GetByIdAsync(int id);
    Task CreateStudantAsync(Estudantes estudante);
    Task UpdateStudantAsync(Estudantes estudante);
    Task DeleteStudantAsync(int id);
}


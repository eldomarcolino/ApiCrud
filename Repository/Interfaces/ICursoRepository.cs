using ApiCrud.Model;

public interface ICursoRepository
{
    Task<IEnumerable<Curso>> GetAllCursoAsync();
    Task<Curso> GetCursoByIdAsync(int id);
    Task CreateCursoAsync(Curso curso);
    Task UpdateCursoAsync(Curso curso);
    Task DeleteCursoAsync(int id);
}
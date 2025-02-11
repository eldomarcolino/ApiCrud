using ApiCrud.Model;

public interface ICursoBusiness
{
    Task<IEnumerable<Curso>> GetAllCursoAsync();
    Task<Curso> GetCursoByIdAsync(int id);
    Task CreateCursoAsync(Curso curso);
    Task UpdateCursoAsync(Curso curso);
    Task DeleteCursoAsync(int id);
}
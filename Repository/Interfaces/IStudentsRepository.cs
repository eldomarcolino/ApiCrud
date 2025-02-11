using ApiCrud.Model;

public interface IStudentsRepository
{
    Task<IEnumerable<Students>> GetAllStudentAsync();
    Task<Students> GetByIdAsync(int id);
    Task CreateStudentAsync(Students estudante);
    Task UpdateStudentAsync(Students estudante);
    Task DeleteStudentAsync(int id);
}
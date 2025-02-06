using ApiCrud.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.Business
{
    public class StudentsBusiness : IStudentsBusiness
    {
        private readonly IStudentsRepository _studentsRepository;

        public StudentsBusiness(IStudentsRepository studentsRepository)
        {
            _studentsRepository = studentsRepository;
        }

        public async Task<IEnumerable<Students>> GetAllStudentAsync()
        {
            return await _studentsRepository.GetAllStudentAsync();
        }

        public async Task<Students> GetByIdAsync(int id)
        {
            return await _studentsRepository.GetByIdAsync(id);
        }

        public async Task CreateStudentAsync(Students estudante)
        {
           await _studentsRepository.CreateStudentAsync(estudante);
        }

        public async Task UpdateStudentAsync(Students estudante)
        {
            await _studentsRepository.UpdateStudentAsync(estudante);
        }

        public async Task DeleteStudentAsync(int id)
        {
            await _studentsRepository.DeleteStudentAsync(id);
        }
    }
}

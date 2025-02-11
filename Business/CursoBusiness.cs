using ApiCrud.Model;
using ApiCrud.Repository;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.Business
{
    public class CursoBusiness : ICursoBusiness
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoBusiness(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public async Task<IEnumerable<Curso>> GetAllCursoAsync()
        {
            return await _cursoRepository.GetAllCursoAsync();
        }

        public async Task<Curso> GetCursoByIdAsync(int id)
        {
            return await _cursoRepository.GetCursoByIdAsync(id);
        }

        public async Task CreateCursoAsync(Curso curso)
        {
            _cursoRepository.CreateCursoAsync(curso);
        }

        public async Task UpdateCursoAsync(Curso curso)
        {
            _cursoRepository.UpdateCursoAsync(curso);
        }

        public async Task DeleteCursoAsync(int id)
        {
            await _cursoRepository.DeleteCursoAsync(id);
        }
    }
}

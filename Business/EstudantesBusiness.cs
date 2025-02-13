using SistemaDeRecarga.Model;

namespace SistemaDeRecarga.Business
{
    public class EstudantesBusiness : IEstudantesBusiness
    {
        private readonly IEstudantesRepository _estudantesRepository;

        public EstudantesBusiness(IEstudantesRepository estudantesRepository)
        {
            _estudantesRepository = estudantesRepository;
        }

        public async Task<IEnumerable<Estudantes>> GetAllEstudantesAsync()
        {
            return await _estudantesRepository.GetAllEstudantesAsync();
        }

        public async Task<Estudantes> GetEstudantesByIdAsync(int id)
        {
            return await _estudantesRepository.GetEstudantesByIdAsync(id);
        }

        public async Task CreateEstudantesAsync(Estudantes estudante)
        {
            await _estudantesRepository.CreateEstudantesAsync(estudante);
        }

        public async Task UpdateEstudantesAsync(Estudantes estudante)
        {
            await _estudantesRepository.UpdateEstudantesAsync(estudante);
        }

        public async Task DeleteEstudantesAsync(int id)
        {
            await _estudantesRepository.DeleteEstudantesAsync(id);
        }
    }
}


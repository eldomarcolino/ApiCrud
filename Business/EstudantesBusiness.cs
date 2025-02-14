using SistemaDeRecarga.Model;
using SistemaDeRecarga.Repository;

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
            if (await _estudantesRepository.EmailAndRegistrationNumberExistAsync(estudante.Email, estudante.RegistrationNumber))
            {
                throw new Exception("Este email ou esta matrícula já foi registrada");
            }

            if (estudante.Id == 0 || estudante.Id == null)
            {
                int lastId = await _estudantesRepository.GetLastIdAsync();
                estudante.Id = lastId + 1;
            }

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


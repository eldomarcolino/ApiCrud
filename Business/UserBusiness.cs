using SistemaDeRecarga.Model;
using SistemaDeRecarga.Repository;

namespace SistemaDeRecarga.Business
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserRepository _userRepository;

        public UserBusiness(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUserAsync()
        {
            return await _userRepository.GetAllUserAsync();
        }

        public async Task<User> CreateUserAsync(User user)
        {
            if (await _userRepository.EmailAndRegistrationNumberExistAsync(user.Email, user.RegistrationNumber))
            {
                throw new Exception("Este email ou esta matrícula já foi registrada");
            }

            if (user.Id == 0 || user.Id == null)
            {
                int lastId = await _userRepository.GetLastIdAsync();
                user.Id = lastId + 1;
            }

            await _userRepository.CreateUserAsync(user);

            return user;
        }

        public async Task UpdateUserAsync(User user)
        {
            _userRepository.UpdateUserAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteUserAsync(id);
        }
    }
}

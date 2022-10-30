using MaViCS.Business.Dtos;
using MaViCS.Business.Interfaces;
using MaViCS.Domain.Interfaces;
using MaViCS.Domain.Models;
using MaViCS.Domain.Repositories;

namespace MaViCS.Business.Services
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            var users = await _userRepository.GetUsers();

            return users.Select(x => x.ToUserDto()).ToList();
        }

        public async Task<UserDto?> GetUserById(long id)
        {
            var user = await _userRepository.GetUserById(id);

            return user?.ToUserDto();
        }

        public async Task<UserDto?> AuthenticateUser(string login, string password)
        {
            var user = await _userRepository.AuthenticateUser(login, password);

            return user?.ToUserDto();
        }

        public async Task<UserDto?> AddUser(CreateUserDto userDto)
        {
            var user = userDto.ToUser();

            user = await _userRepository.AddUser(user);

            return user?.ToUserDto();
        }

        public async Task<UserDto?> UpdateUser(long id, UpdateUserDto userDto)
        {
            var user = await _userRepository.GetUserById(id);

            if (user == null)
                return null;

            user = user.UpdateUser(userDto);

            user = await _userRepository.UpdateUser(user);

            return user?.ToUserDto();
        }

        public async Task<UserDto?> UpdateUserRole(long id, UpdateUserRoleDto userDto)
        {
            var user = await _userRepository.GetUserById(id);

            if (user == null)
                return null;

            user.Role = userDto.Role;

            user = await _userRepository.UpdateUser(user);

            return user?.ToUserDto();
        }

        public async Task<bool> ArchiveUser(long id)
        {
            return await _userRepository.ArchiveUser(id);
        }

        public async Task<bool> DeleteUser(long id)
        {
            return await _userRepository.DeleteUser(id);
        }

    }
}

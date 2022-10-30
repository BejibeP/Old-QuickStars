using MaViCS.Business.Dtos;
using MaViCS.Business.Interfaces;
using MaViCS.Domain.Framework;
using MaViCS.Domain.Framework.Configuration;
using MaViCS.Domain.Interfaces;
using Microsoft.Extensions.Options;

namespace MaViCS.Business.Services
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;
        private readonly IOptions<JwtSettings> _jwtSettings;

        public UserService(IUserRepository userRepository, IOptions<JwtSettings> jwtSettings)
        {
            _userRepository = userRepository;
            _jwtSettings = jwtSettings;
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

        public async Task<TokenDto?> AuthenticateUser(string login, string password)
        {
            var user = await _userRepository.AuthenticateUser(login, PasswordTool.HashPassword(password));

            if (user is null)
                return null;

            JwtSettings jwtSettings = _jwtSettings.Value;

            TokenDto token = new TokenDto()
            {
                Username = user.Username,
                Token = TokenTool.GenerateJwt(user, jwtSettings)
            };

            return token;
        }

        public async Task<UserDto?> AddUser(CreateUserDto userDto)
        {
            var user = userDto.ToUser();

            user.Password = PasswordTool.HashPassword(userDto.Password);

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

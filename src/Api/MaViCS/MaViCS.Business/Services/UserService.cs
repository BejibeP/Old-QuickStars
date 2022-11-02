using MaViCS.Business.Dtos;
using MaViCS.Business.Interfaces;
using MaViCS.Domain.Framework.Authentication;
using MaViCS.Domain.Interfaces;

namespace MaViCS.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly AuthHelper _securityHelper;

        public UserService(IUserRepository userRepository, AuthHelper securityHelper)
        {
            _userRepository = userRepository;
            _securityHelper = securityHelper;
        }


        public async Task<UserDto?> RegisterUser(RegisterUserDto userDto)
        {
            userDto.Password = _securityHelper.HashPassword(userDto.Password);

            var user = await _userRepository.Create(userDto.ToUser());

            return user?.ToUserDto();
        }

        public async Task<AuthToken?> LoginUser(LoginUserDto loginDto)
        {
            string hashedPassword = _securityHelper.HashPassword(loginDto.Password);

            var user = await _userRepository.GetUserByLoginAndPassword(loginDto.Login, hashedPassword);

            if (user is null)
                return null;

            user.LastLoggedOn = DateTime.UtcNow;
            await _userRepository.Update(user);

            return _securityHelper.GenerateToken(user);
        }

        public async Task<UserDto?> ResetPassword(ResetPasswordDto passwordDto)
        {
            string hashedPassword = _securityHelper.HashPassword(passwordDto.Password);

            var user = await _userRepository.GetUserByLoginAndPassword(passwordDto.Login, hashedPassword);

            if (user is null)
                return null;

            user.Password = _securityHelper.HashPassword(passwordDto.NewPassword);
            user.ResetPassword = false;

            var updatedUser = await _userRepository.Update(user);

            return updatedUser?.ToUserDto();
        }


        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            var users = await _userRepository.GetAll();
            return users.Select(x => x.ToUserDto()).ToList();
        }

        public async Task<UserDto?> GetUserById(long id)
        {
            var user = await _userRepository.GetById(id);
            return user?.ToUserDto();
        }

        public async Task<UserDto?> UpdateUser(long id, UpdateUserDto userDto)
        {
            var user = await _userRepository.GetById(id);

            if (user is null) return null;

            var updatedUser = await _userRepository.Update(user.UpdateUser(userDto));

            return updatedUser?.ToUserDto();
        }

        public async Task<UserDto?> ManageUser(long id, ManageUserDto userDto)
        {
            var user = await _userRepository.GetById(id);

            if (user is null) return null;

            var updatedUser = await _userRepository.Update(user.UpdateUser(userDto));

            return updatedUser?.ToUserDto();
        }

        public async Task<bool> ArchiveUser(long id)
        {
            return await _userRepository.Archive(id);
        }

        public async Task<bool> DeleteUser(long id)
        {
            return await _userRepository.Delete(id);
        }

    }
}

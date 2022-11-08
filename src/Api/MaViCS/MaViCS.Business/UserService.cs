using QuickStars.MaViCS.Business.RW.Interfaces;

namespace QuickStars.MaViCS.Business.RW.Services
{
    public class UserService : IUserService
    {
        /*
        private readonly IUserRepository _userRepository;
        private readonly ISecurityService _securityService;

        public UserService(IUserRepository userRepository, ISecurityService securityService)
        {
            _userRepository = userRepository;
            _securityService = securityService;
        }

        public async Task<UserDto?> RegisterUser(RegisterDto userDto)
        {
            //userDto.Password = _securityService.HashPassword(userDto.Password);

            var user = await _userRepository.Create(userDto.ToUser());

            return user?.ToUserDto();
        }

        public async Task<AuthToken?> LoginUser(LoginDto loginDto)
        {
            //string hashedPassword = _securityService.HashPassword(loginDto.Password);

            var user = await _userRepository.GetUserByLoginAndPassword(loginDto.Username, "");

            if (user is null)
                return null;

            user.LastLoggedOn = DateTime.UtcNow;
            await _userRepository.Update(user);

            return _securityService.GenerateAuthToken(user);
        }

        public async Task<UserDto?> ResetPassword(ResetPasswordDto passwordDto)
        {
            //string hashedPassword = _securityService.HashPassword(passwordDto.Password);

            var user = await _userRepository.GetUserByLoginAndPassword(passwordDto.Login, "");

            if (user is null)
                return null;

            //user.Password = _securityService.HashPassword(passwordDto.NewPassword);
            user.ResetPassword = false;

            var updatedUser = await _userRepository.Update(user);

            return updatedUser?.ToUserDto();
        }


        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            var users = await _userRepository.GetAll();
            return users.Select(e => e.ToUserDto()).ToList();
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
        */
    }
}

using MaViCS.Business.Dtos;
using MaViCS.Domain.Framework.Authentication;

namespace MaViCS.Business.Interfaces
{
    public interface IUserService
    {

        Task<UserDto?> RegisterUser(RegisterUserDto userDto);

        Task<AuthToken?> LoginUser(LoginUserDto loginDto);

        Task<UserDto?> ResetPassword(ResetPasswordDto passwordDto);


        Task<IEnumerable<UserDto>> GetAllUsers();

        Task<UserDto?> GetUserById(long id);

        Task<UserDto?> UpdateUser(long id, UpdateUserDto userDto);

        Task<UserDto?> ManageUser(long id, ManageUserDto userDto);

        Task<bool> ArchiveUser(long id);

        Task<bool> DeleteUser(long id);

    }
}

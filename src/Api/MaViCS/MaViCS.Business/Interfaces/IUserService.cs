using MaViCS.Business.Dtos;

namespace MaViCS.Business.Interfaces
{
    public interface IUserService
    {

        Task<IEnumerable<UserDto>> GetUsers();

        Task<UserDto?> GetUserById(long id);

        Task<UserDto?> AuthenticateUser(string login, string password);

        Task<UserDto?> AddUser(CreateUserDto userDto);

        Task<UserDto?> UpdateUser(long id, UpdateUserDto userDto);

        Task<UserDto?> UpdateUserRole(long id, UpdateUserRoleDto userDto);

        Task<bool> ArchiveUser(long id);

        Task<bool> DeleteUser(long id);

    }
}

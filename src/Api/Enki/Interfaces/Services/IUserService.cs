using Enki.Domain.Dtos;

namespace Enki.Interfaces.Services
{
    public interface IUserService
    {
        List<UserDto> GetAllUsers();

        UserDto AddUser(AddUserDto userDto);
    }
}

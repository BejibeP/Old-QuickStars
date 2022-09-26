using Enki.Domain.Dtos;
using Enki.Domain.Models;
using Enki.Interfaces.Repository;
using Enki.Interfaces.Services;
using System.Linq;

namespace Enki.Services
{
    public class UserService : IUserService
    {
        public IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<UserDto> GetAllUsers()
        {
            var users = _userRepository.GetAllUsers();

            var userDtos = users.Select(x =>
                new UserDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Surname = x.Surname,
                    Email = x.Email,
                    Order = x.Order,
                    RegisteredOn = x.RegisteredOn
                }).ToList();

            return userDtos;
        }

        public UserDto AddUser(AddUserDto userDto)
        {
            var user = new User
            {
                Name = userDto.Name,
                Surname = userDto.Surname,
                Email = userDto.Email,
                RegisteredOn = userDto.RegisteredOn,
                Order = userDto.Order
            };

            var newUser = _userRepository.AddUser(user, userDto.Password);

            return new UserDto()
            {
                Id = newUser.Id,
                Name = newUser.Name,
                Surname = newUser.Surname,
                Email = newUser.Email,
                RegisteredOn = newUser.RegisteredOn,
                Order = newUser.Order
            };

        }


    }
}

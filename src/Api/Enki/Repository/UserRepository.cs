using Enki.Domain;
using Enki.Domain.Models;
using Enki.Interfaces.Repository;
using Enki.Tools;

namespace Enki.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _databaseContext;

        public UserRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<User> GetAllUsers()
        {
            return _databaseContext.Users.ToList();
        }

        public User AddUser(User newUser, string clearPassword)
        {
            newUser.Password = SecurityTools.HashPassword(clearPassword);

            _databaseContext.Add(newUser);
            _databaseContext.SaveChanges();

            newUser.Id = newUser.Id;

            return newUser;
        }

        public User AuthenticateUser(string email, string password)
        {
            var user = _databaseContext.Users.Where(x => x.Email == email).FirstOrDefault();

            if (user != null && user.Password == SecurityTools.HashPassword(password))
            {
                return user;
            }
            return null;
        }


    }
}

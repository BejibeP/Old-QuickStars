using Enki.Domain.Dtos;
using Enki.Interfaces.Repository;
using Enki.Interfaces.Services;
using Enki.Tools;
using Microsoft.Extensions.Options;
using static Enki.Tools.SecurityTools;

namespace Enki.Services
{
    public class AuthenticateService : IAuthenticateService
    {

        public IUserRepository _userRepository;
        private readonly IOptions<JwtSettings> _jwtSettings;

        public AuthenticateService(IUserRepository userRepository, IOptions<JwtSettings> jwtSettings)
        {
            _userRepository = userRepository;
            _jwtSettings = jwtSettings;
        }

        public TokenDto ConnectUser(AuthenticateDto request)
        {

            var existingUser = _userRepository.AuthenticateUser(request.Mail, request.Password);
            if (existingUser != null)
            {
                return new TokenDto
                {
                    Mail = existingUser.Email,
                    Token = SecurityTools.GenerateJwt(existingUser, _jwtSettings.Value)
                };
            }

            return null;
        }
    }
}

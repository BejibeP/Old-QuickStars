using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MaViCS.Domain.Framework.Configuration;
using MaViCS.Domain.Framework.Habilitation;
using MaViCS.Domain.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace MaViCS.Domain.Framework.Authentication
{
    public class AuthHelper
    {
        private readonly AuthSettings _settings;

        public const string InvalidPasswordErrorMessage = "Your password needs to have at least : \n - 8 characters \n - 1 lowercase character \n - 1 uppercase character \n - 1 digit \n - 1 special character \n ";

        public AuthHelper(IOptions<AuthSettings> settings)
        {
            _settings = settings.Value;
        }

        public bool VerifyPassword(string password)
        {
            Regex pwdRegex = new Regex("(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*)(?=.*[^A-Za-z0-9])(?=.{8,})");

            return pwdRegex.IsMatch(password);
        }

        public string HashPassword(string password)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: Encoding.UTF8.GetBytes(_settings.Salt),
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashed;
        }

        public AuthToken GenerateToken(User user)
        {
            //create claims details based on the user information
            var claims = new[] {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role.ToUserRole().Name)
            };

            byte[] secret = Encoding.UTF8.GetBytes(_settings.TokenSettings.Secret);

            var key = new SymmetricSecurityKey(secret);
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            string issuer = _settings.TokenSettings.Issuer;
            string audience = _settings.TokenSettings.Audience;
            var expires = DateTime.Now.AddMinutes(_settings.TokenSettings.ExpirationInMinutes);

            var token = new JwtSecurityTokenHandler()
                .WriteToken(new JwtSecurityToken(issuer, audience, claims, null, expires, creds));

            return new AuthToken(user.Username, token);
        }

    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using QuickStars.MaViCS.Business.Dtos.Auth;
using QuickStars.MaViCS.Business.Interfaces;
using QuickStars.MaViCS.Domain.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace QuickStars.MaViCS.Business.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IdentitySettings _settings;

        public AuthService(UserManager<IdentityUser> userManager, IOptions<IdentitySettings> settings)
        {
            _userManager = userManager;
            _settings = settings.Value;
        }

        public async Task<ServiceResult<TokenDto>> Login(LoginDto dto)
        {
            var user = await _userManager.FindByNameAsync(dto.Username);
            if (user is null)
                return ServiceResult<TokenDto>.NotFound("User does not exists");

            bool passwordIsValid = await _userManager.CheckPasswordAsync(user, dto.Password);
            if (!passwordIsValid)
                return ServiceResult<TokenDto>.ServerError("Incorrect password");

            var userRoles = await _userManager.GetRolesAsync(user);

            var jwtToken = GenerateJwtToken(user, userRoles);

            var tokenDto = new TokenDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                Expiration = jwtToken.ValidTo
            };

            return ServiceResult<TokenDto>.Success(tokenDto);
        }

        public async Task<ServiceResult<bool>> Register(RegisterDto dto)
        {
            var userExists = await _userManager.FindByNameAsync(dto.Username);
            if (userExists is not null)
                return ServiceResult<bool>.ServerError("User already exists !");

            var user = new IdentityUser
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = dto.Username
            };
            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
                return ServiceResult<bool>.ServerError("User creation failed! Please check user details and try again.");

            return ServiceResult<bool>.Success("User created sucessfuly");
        }

        public async Task<ServiceResult<bool>> ResetPassword(ResetPasswordDto dto)
        {
            var user = await _userManager.FindByNameAsync(dto.Username);
            if (user is null)
                return ServiceResult<bool>.NotFound("User does not exists");

            var result = await _userManager.ChangePasswordAsync(user, dto.Password, dto.NewPassword);

            if (!result.Succeeded)
                return ServiceResult<bool>.ServerError("Password change failed! Please check user details and try again.");

            return ServiceResult<bool>.Success("Password sucessfuly updated");
        }

        private JwtSecurityToken GenerateJwtToken(IdentityUser user, IEnumerable<string> userRoles)
        {
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            DateTime expires = DateTime.Now.AddHours(_settings.ExpirationInMinutes);

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Secret));
            var credentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256);

            return new JwtSecurityToken(_settings.Issuer, _settings.Audience, authClaims, null, expires, credentials);
        }
    }
}

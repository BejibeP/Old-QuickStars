using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using QuickStars.MaViCS.Business.Dtos.Auth;
using QuickStars.MaViCS.Business.Interfaces.Auth;
using QuickStars.MaViCS.Domain.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace QuickStars.MaViCS.Business.Services.Auth
{
    public class AuthService : IAuthService
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IdentitySettings _settings;

        public AuthService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<IdentitySettings> settings)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _settings = settings.Value;
        }

        public async Task<ServiceResult> Register(RegisterDto dto)
        {
            var userExists = await _userManager.FindByNameAsync(dto.Username);
            if (userExists is not null)
                return ServiceResult.Error("User Already Exist");

            IdentityUser user = new()
            {
                Email = dto.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = dto.Username
            };
            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
                return ServiceResult.Error("User creation failed! Please check user details and try again.");

            return ServiceResult.Success();
        }

        private void Test()
        {
            /*
            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.Admin);
            }
            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.User);
            }
            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
            */
        }

        public async Task<ServiceResult> Login(LoginDto dto)
        {
            var user = await _userManager.FindByNameAsync(dto.Username);

            if (user is null)
                return ServiceResult.NotFound("User does not exists");

            bool passwordIsValid = await _userManager.CheckPasswordAsync(user, dto.Password);
            if (!passwordIsValid)
                return ServiceResult.Error("Incorrect password");

            var userRoles = await _userManager.GetRolesAsync(user);

            var jwtToken = GenerateJwtToken(user, userRoles);

            var tokenDto = new TokenDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                Expiration = jwtToken.ValidTo
            };

            return ServiceResult<TokenDto>.Success(tokenDto);
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

        public async Task<ServiceResult> GetUserInfos(ClaimsPrincipal userClaim)
        {
            var user = this;

            var id = GetId(userClaim);
            var claims = userClaim.Claims.ToDictionary(claim => claim.Type, claim => claim.Value);
            //this.User.GetId(),

            var dto = new UserInfoDto()
            {
                Id = id,
                Claims = claims
            };

            return ServiceResult<UserInfoDto>.Success(dto);
        }

        private string GetId(ClaimsPrincipal principal)
        {
            var userIdClaim = principal.FindFirst(c => c.Type == ClaimTypes.NameIdentifier) ?? principal.FindFirst(c => c.Type == "sub");
            if (userIdClaim != null && !string.IsNullOrEmpty(userIdClaim.Value))
            {
                return userIdClaim.Value;
            }
            return "";
        }

    }
}

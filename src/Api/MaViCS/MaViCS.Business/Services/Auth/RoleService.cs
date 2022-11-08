using Microsoft.AspNetCore.Identity;
using QuickStars.MaViCS.Business.Interfaces.Auth;

namespace QuickStars.MaViCS.Business.Services.Auth
{
    public class RoleService : IRoleService
    {

        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleService(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

    }
}

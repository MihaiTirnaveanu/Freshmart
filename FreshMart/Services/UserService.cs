using FreshMart.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace FreshMart.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(UserManager<IdentityUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public IdentityUser GetCurrentLoggedInUser()
        {
            return _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User).Result;
        }

    }
}

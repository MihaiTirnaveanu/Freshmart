using Microsoft.AspNetCore.Identity;

namespace FreshMart.Services.Interfaces
{
    public interface IUserService
    {
        IdentityUser GetCurrentLoggedInUser();
    }
}

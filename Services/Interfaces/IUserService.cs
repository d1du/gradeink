using Derek.Web.Models;
using Derek.Web.Models.Register;
using Derek.Web.Models.SignIn;
using Derek.Web.Models.Users;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Derek.Web.Services.Interfaces
{
    public interface IUserService
    {
        IdentityUser GetCurrentUser();
        IdentityUser CreateUser(RegisterRequest model);
        bool IsLoggedIn();
        bool Logout();
        Task<bool> Signin(SignInRequest model);
        int Insert(UserAddRequest model);
        int Insert(RegisterRequest model, string userId);
        string GetCurrentUserId();
        //bool EmailConfirmation(string newUserId, string email);
    }
}
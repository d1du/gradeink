using Derek.Web.Exceptions;
using Derek.Web.Models;
using Derek.Web.Models.Register;
using Derek.Web.Services.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Routing;
using System.Web.Routing;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System.Security.Claims;
using Derek.Web.Models.SignIn;
using Derek.Web.Models.Users;
using Derek.Web.Domain;
using Sabio.Data;

namespace Derek.Web.Services
{
    public class UserService : BaseService
    {
        private readonly ApplicationUserManager _userManager;
        private readonly IAuthenticationManager _authenticationManager;
        //private readonly IMessagingService _messagingService;

        public UserService(ApplicationUserManager userManager, IAuthenticationManager authenticationManager, IMessagingService messagingService)
        {
            _userManager = userManager;
            _authenticationManager = authenticationManager;
        }

        public IdentityUser CreateUser(RegisterRequest model)
        {
            ApplicationUser newUser = new ApplicationUser { UserName = model.Email, Email = model.Email, LockoutEnabled = false };
            IdentityResult result = null;
            try
            {
                result = _userManager.Create(newUser, model.Password);
            }
            catch (Exception)
            {
                throw;
            }

            if (!result.Succeeded)
            {
                throw new IdentityResultException(result);
            }

            //EmailConfirmation(newUser.Id, newUser.Email);

            Insert(model, newUser.Id);

            return newUser;
        }

        public async Task<bool> Signin(SignInRequest model)
        {
            ApplicationUser user = await _userManager.FindAsync(model.EmailAddress, model.Password);
            if (user == null)
            {
                throw new Exception("The Email/ Password is incorrect");
            }
            else if (user.EmailConfirmed == false)
            {
                throw new Exception("Login Credentials is not valid");
            }
            await SignInAsync(user, model.RememberMe);

            return true;
        }

        private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            _authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            ClaimsIdentity identity = await _userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            _authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        public bool IsLoggedIn()
        {
            return !string.IsNullOrEmpty(GetCurrentUserId());
        }

        public bool Logout()
        {
            _authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return true;
        }

        //public bool EmailConfirmation(string newUserId, string email)
        //{
        //    string ConfirmationCode = _userManager.GenerateEmailConfirmationToken(newUserId);

        //    RequestContext requestContext = HttpContext.Current.Request.RequestContext;

        //    string callbackURL = new System.Web.Mvc.UrlHelper(requestContext).

        //        Action("ConfirmEmail", "Register", new { userId = newUserId, code = ConfirmationCode }

        //        , protocol: HttpContext.Current.Request.Url.Scheme);

        //    _messagingService.SendEmailConfirmation(email, callbackURL);

        //    return true;
        //}

        public int Insert(RegisterRequest model, string userId)
        {
            int id = 0;

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Users_Insert"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   if (model != null)
                   {
                       paramCollection.AddWithValue("@FirstName", model.FirstName);
                       paramCollection.AddWithValue("@LastName", model.LastName);
                       paramCollection.AddWithValue("@Email", model.Email);
                       paramCollection.AddWithValue("@UserType", model.UserType);
                       paramCollection.AddWithValue("@AspNetUserId", userId);
                   }

                   SqlParameter p = new SqlParameter("@Id", SqlDbType.Int);
                   p.Direction = ParameterDirection.Output;

                   paramCollection.Add(p);
               }, returnParameters: delegate (SqlParameterCollection param)
               {
                   int.TryParse(param["@Id"].Value.ToString(), out id);
               }
               );

            return id;
        }

        public int Insert(UserAddRequest model)
        {
            throw new NotImplementedException();
        }
        public IdentityUser GetCurrentUser()
        {
            if (!IsLoggedIn())
            {
                return null;
            }

            else {
                IdentityUser currentUserId = _userManager.FindById(GetCurrentUserId());
                return currentUserId;
            }
        }

        public static string GetCurrentUserId()
        {
            return HttpContext.Current.User.Identity.GetUserId();
        }

        ////////////////////////////

        public static int AddUser(UserAddRequest model, string UserId)
        {
            int id = 0;

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.AddUser"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   if (model != null)
                   {
                       paramCollection.AddWithValue("@FirstName", model.FirstName);
                       paramCollection.AddWithValue("@LastName", model.LastName);
                       paramCollection.AddWithValue("@Email", model.Email);
                       paramCollection.AddWithValue("@UserType", model.UserType);
                       paramCollection.AddWithValue("@Period", model.Period);
                       paramCollection.AddWithValue("@UserId", UserId);
                   }

                   SqlParameter p = new SqlParameter("@Id", SqlDbType.Int);
                   p.Direction = ParameterDirection.Output;

                   paramCollection.Add(p);
               }, returnParameters: delegate (SqlParameterCollection param)
               {
                   int.TryParse(param["@Id"].Value.ToString(), out id);
               }
               );

            return id;

        }

        public static void UpdateUser(UserUpdateRequest model)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.UpdateUserByIntId"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@Id", model.Id);
                   paramCollection.AddWithValue("@FirstName", model.FirstName);
                   paramCollection.AddWithValue("@LastName", model.LastName);
                   paramCollection.AddWithValue("@Email", model.Email);
                   paramCollection.AddWithValue("@UserType", model.UserType);
                   paramCollection.AddWithValue("@Period", model.Period);

               }, returnParameters: delegate (SqlParameterCollection param)
               { }
               );
        }

        public static List<User> GetAllUsers()
        {
            List<User> list = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.SelectAllUsers"
               , inputParamMapper: null
               , map: delegate (IDataReader reader, short set)
               {
                   User p = new User();
                   int startingIndex = 0;

                   p.Id = reader.GetSafeInt32(startingIndex++);
                   p.FirstName = reader.GetSafeString(startingIndex++);
                   p.LastName = reader.GetSafeString(startingIndex++);
                   p.UserId = reader.GetSafeString(startingIndex++);
                   p.Period = reader.GetSafeInt32(startingIndex++);
                   p.UserType = reader.GetSafeInt32(startingIndex++);
                   p.Email = reader.GetSafeString(startingIndex++);

                   if (list == null)
                   {
                       list = new List<User>();
                   }

                   list.Add(p);
               }
               );

            return list;
        }

        public static User SelectUserById(int id)
        {
            User p = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.SelectUserById"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@Id", id);
               }, map: delegate (IDataReader reader, short set)
               {
                   p = new User();
                   int startingIndex = 0;

                   p.Id = reader.GetSafeInt32(startingIndex++);
                   p.FirstName = reader.GetSafeString(startingIndex++);
                   p.LastName = reader.GetSafeString(startingIndex++);
                   p.UserId = reader.GetSafeString(startingIndex++);
                   p.Period = reader.GetSafeInt32(startingIndex++);
                   p.UserType = reader.GetSafeInt32(startingIndex++);
                   p.Email = reader.GetSafeString(startingIndex++);
               });

            return p;
        }

        public static void DeleteUserById(int id)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.DeleteUserById"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@Id", id);
               }, returnParameters: delegate (SqlParameterCollection param)
               {
               }
               );
        }

        public static string GetUserIdByIntId(int id)
        {
            string s = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.GetUserIdByIntId"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@IntId", id);
               }, map: delegate (IDataReader reader, short set)
               {
                   s = reader.GetSafeString(0);
               });

            return s;
        }

        public static List<BaseUser> GetUsersByPeriod(int period)
        {
            List<BaseUser> list = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.GetUsersByPeriod"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@Period", period);
               }
               , map: delegate (IDataReader reader, short set)
               {
                   BaseUser p = new BaseUser();
                   int startingIndex = 0;

                   p.Id = reader.GetSafeInt32(startingIndex++);
                   p.FirstName = reader.GetSafeString(startingIndex++);
                   p.LastName = reader.GetSafeString(startingIndex++);
                   p.UserId = reader.GetSafeString(startingIndex++);
                   p.UserType = reader.GetSafeInt32(startingIndex++);

                   if (list == null)
                   {
                       list = new List<BaseUser>();
                   }

                   list.Add(p);
               }
               );

            return list;
        }

    }
}
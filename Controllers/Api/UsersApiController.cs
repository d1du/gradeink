using Derek.Web.Domain;
using Derek.Web.Models.Responses;
using Derek.Web.Models.Users;
using Derek.Web.Services;
using Derek.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Derek.Web.Controllers.Api
{
    [RoutePrefix("api/users")]
    public class UsersApiController : ApiController
    {
        //private IUserService _userService;

        //public UsersApiController(IUserService UserService)
        //{
        //    _userService = UserService;
        //}

        [Route, HttpPost]
        public HttpResponseMessage AddUser(UserAddRequest model)
        {
            string userId = Guid.NewGuid().ToString();
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            ItemResponse<int> response = new ItemResponse<int>();

            response.Item = UserService.AddUser(model, userId);

            return Request.CreateResponse(response);
        }

        [Route("{id:int}"), HttpPut]
        public HttpResponseMessage UpdateUser(UserUpdateRequest model, int id)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            model.Id = id;
            SuccessResponse response = new SuccessResponse();

            UserService.UpdateUser(model);

            return Request.CreateResponse(response);
        }

        [Route, HttpGet]
        public HttpResponseMessage GetAllUsers()
        {
            ItemsResponse<User> response = new ItemsResponse<User>();

            response.Items = UserService.GetAllUsers();

            return Request.CreateResponse(response);
        }

        [Route("{id:int}"), HttpGet]
        public HttpResponseMessage GetUserById(int id)
        {
            ItemResponse<User> response = new ItemResponse<User>();

            response.Item = UserService.SelectUserById(id);

            return Request.CreateResponse(response);
        }

        [Route("{id:int}"), HttpDelete]
        public HttpResponseMessage DeleteUserById(int id)
        {
            SuccessResponse response = new SuccessResponse();

            UserService.DeleteUserById(id);

            return Request.CreateResponse(response);
        }

        [Route("userIntId/{id:int}"), HttpGet]
        public HttpResponseMessage GetUserIdByIntId(int id)
        {
            ItemResponse<string> response = new ItemResponse<string>();

            response.Item = UserService.GetUserIdByIntId(id);

            return Request.CreateResponse(response);
        }

        [Route("period/{id:int}"), HttpGet]
        public HttpResponseMessage GetUsersByPeriod(int id)
        {
            ItemsResponse<BaseUser> response = new ItemsResponse<BaseUser>();

            response.Items = UserService.GetUsersByPeriod(id);

            return Request.CreateResponse(response);
        }

    }
}
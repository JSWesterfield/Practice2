using Stark.Starter.Template.Web.Services.Interfaces;
using Stark.Web.Domain;
using Stark.Web.Models.Requests;
using Stark.Web.Models.Responses;
using Stark.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace Stark.Web.Controllers.Api
{
    [RoutePrefix("api/users")]
    public class UsersApiController : BaseApiController
    {
        private IUsersService _usersService;

        public UsersApiController(IUsersService usersService) // constructor
        {
            _usersService = usersService;
        }

        private bool PasswordCheck(string password)
        {
            bool hasUppercase = Regex.IsMatch(password, "[A-Z]");
            bool hasLowercase = Regex.IsMatch(password, "[a-z]");
            bool hasNumbers = Regex.IsMatch(password, "[0-9]");
            bool hasSpecialChars = Regex.IsMatch(password, "[^a-zA-Z0-9]");
            int counter = 0;
            if (hasUppercase)
            {
                counter++;
            }
            if (hasLowercase)
            {
                counter++;
            }
            if (hasNumbers)
            {
                counter++;
            }
            if (hasSpecialChars)
            {
                counter++;
            }
            if (counter > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [Route(""), HttpPost]
        public HttpResponseMessage Create(UserCreateRequest model)
        {
            if (model == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Request body cannot be empty");
            }

            if (model.Password == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }

            bool passwordValid = PasswordCheck(model.Password);

            if (!passwordValid)
            {
                ModelState.AddModelError("password", "Password must have a character from two of following categories: numbers, lowercase letters, uppercase letters, special characters.");
            }
            if (model.Password.Length < 6)
            {
                ModelState.AddModelError("password", "Password must have at least 6 characters.");
            }
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }

            int generatedId = _usersService.Create(model);
            ItemResponse<int> response = new ItemResponse<int>();
            response.Item = generatedId;

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("{id:int}"), HttpPut]
        public HttpResponseMessage Update(UserUpdateRequest model, int id)
        {
            if (model.Id != id)
            {
                ModelState.AddModelError("id", "can't change your id");
            }
            if (model == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Request body cannot be empty");
            }
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }

            bool passwordValid = PasswordCheck(model.Password);

            if (!passwordValid)
            {
                ModelState.AddModelError("password", "Password must have a character from two of following categories: numbers, lowercase letters, uppercase letters, special characters.");
            }
            if (model.Password.Length < 6)
            {
                ModelState.AddModelError("password length", "Password must have at least 6 characters.");
            }
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }

            _usersService.Update(model);
            SuccessResponse response = new SuccessResponse();
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route(""), HttpGet]
        public HttpResponseMessage GetAll()
        {
            ItemsResponse<User> response = new ItemsResponse<User>();
            response.Items = _usersService.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("{id:int}"), HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            ItemResponse<User> response = new ItemResponse<User>();
            response.Item = _usersService.GetById(id);

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("{id:int}"), HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            _usersService.Delete(id);

            SuccessResponse response = new SuccessResponse();
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("login"), HttpPost]
        public HttpResponseMessage Login(UserLoginRequest model)
        {
            if (model.Username == null || model.Password == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Request body cannot be empty");
            }
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }

            int? response = _usersService.GetId(model.Username, model.Password);

            if (response == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Can't find anyone with that info");
            }

            Services.AuthenticationService authService = new Services.AuthenticationService();

            authService.SignIn(response.Value, model.Username);

            SuccessResponse successResponse = new SuccessResponse();
            return Request.CreateResponse(HttpStatusCode.OK, successResponse);
        }

        //[Route("logout"), HttpPost]
        //public HttpResponseMessage Logout()
        //{
        //    Services.AuthenticationService authService = new Services.AuthenticationService();
        //    authService.Logout();


        //}
    }
}




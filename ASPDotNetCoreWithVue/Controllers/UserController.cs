using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPDotNetCoreWithVue.Models;
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service;

namespace ASPDotNetCoreWithVue.Controllers
{
    public class UserController : Controller
    {
        private readonly DefaultDbContext _dbContext;
        private readonly AuthInfoService _authInfoService;

        public UserController(DefaultDbContext dbContext,AuthInfoService authInfoService)
        {
            _dbContext = dbContext;
            _authInfoService = authInfoService;
        }
        public JsonResult Login([FromBody] AuthInfo user)
        {
            JsonResult json = null;
            
            var token = _authInfoService.LoginAuth(user);
            if ( !String.IsNullOrEmpty(token))
            {
                json = new JsonResult(new
                {
                    code = 20000,
                    data = new { token = token }
                });
            }
            else
            {
                json = new JsonResult(new
                {
                    code = 60204,
                    message= "Account and password are incorrect."
                });
            }
            return json;
        }

        public JsonResult Info(string token)
        {
            JsonResult result = null;
            AuthInfo auth = _authInfoService.GetAuth(token);
            if (auth.UserInfo != null)
            {
                var user = new Models.UserInfo();
                user.Name = auth.UserInfo.Name;
                user.Avatar = auth.UserInfo.Avatar;
                user.Introduction = auth.UserInfo.Introduction;
                user.roles = new List<string>();
                foreach(var i in auth.UserInfo.Roles)
                {
                    user.roles.Add(i.Name);
                }
                result = new JsonResult(new {
                    code= 20000,
                    data=user });
            }
            else
            {
                result = new JsonResult(new {
                    code=50008,
                    message= "Login failed, unable to get user details." });
            }

            return result;
        }
        public JsonResult Logout()
        {
            return new JsonResult(new {
                code = 20000, 
                data= "success" });
        }
    }
}

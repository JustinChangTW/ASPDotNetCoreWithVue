using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPDotNetCoreWithVue.Models;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPDotNetCoreWithVue.Controllers
{
    public class UserController : Controller
    {
        private readonly DefaultDbContext _dbContext;

        public UserController(DefaultDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public JsonResult Login([FromBody] UserAuthInfo user)
        {
            JsonResult json = null;
            var data = _dbContext.AuthInfo.
                       FirstOrDefault(x=>x.UserName == user.Username && x.Password == user.Password);
            if (data != null)
            {
                data.Token = Guid.NewGuid().ToString();
                _dbContext.SaveChanges();
                json = new JsonResult(new
                {
                    code = 20000,
                    data = new { token = data.Token }
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
            var auth = _dbContext.AuthInfo.Include(x=>x.UserInfo.Roles).FirstOrDefault(x => x.Token == token);

            if (auth.UserInfo != null)
            {
                var user = new UserInfo();
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

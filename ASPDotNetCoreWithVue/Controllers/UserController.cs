using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPDotNetCoreWithVue.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPDotNetCoreWithVue.Controllers
{
    public class UserController : Controller
    {
        public JsonResult Login([FromBody] UserAuthInfo user)
        {
            return new JsonResult(new { 
                code = 20000, 
                data = new { token = "abcd" } });
        }

        public JsonResult Info(string token)
        {
            return new JsonResult(new {
                code = 20000, 
                data = GetUserInfo("abcd") });
        }
        public JsonResult Logout()
        {
            return new JsonResult(new {
                code = 20000, 
                data= "success" });
        }

        public UserInfo GetUserInfo(string Token)
        {
            return new UserInfo { 
                Id = "1", 
                Name = "Super Admin",
                Introduction = "I am a super administrator",
                Avatar = "https://wpimg.wallstcn.com/f778738c-e4f8-4870-b634-56703b4acafe.gif",
                roles = new List<string> { "Admin" }
            };
        }
    }
}

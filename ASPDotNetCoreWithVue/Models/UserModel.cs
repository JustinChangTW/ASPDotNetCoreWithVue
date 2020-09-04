using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPDotNetCoreWithVue.Models
{
    public class UserInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Introduction { get; set; }
        public string Avatar { get; set; }
        public string Token { get; set; }
        public List<string> roles { get; set; }
    }

    public class UserAuthInfo
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

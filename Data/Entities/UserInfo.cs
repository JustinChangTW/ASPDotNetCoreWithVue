using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Entities
{
    public class UserInfo
    {
        [Key]
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Introduction { get; set; }
        public string Avatar { get; set; }
        public List<RoleInfo> Roles { get; set; }
    }
}

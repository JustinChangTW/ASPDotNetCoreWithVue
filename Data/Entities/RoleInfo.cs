using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Entities
{
    public class RoleInfo
    {
        [Key]
        public string RoleId { get; set; }
        public string Name { get; set; }
    }
}

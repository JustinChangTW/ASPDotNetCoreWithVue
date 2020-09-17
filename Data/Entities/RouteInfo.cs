using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Entities
{
    public class RouteInfo
    {
        [Key]
        public string RouteId { get; set; }
        public string Path { get; set; }
        public string Component { get; set; }
        public string Redirect { get; set; }
        public string Name { get; set; }
        public bool Hidden { get; set; }
        public bool AlwaysShow { get; set; }
        public Meta Meta { get; set; }
        public List<RouteInfo> Children { get; set; }
    }

    public class RouteRole
    {
        [Key]
        public string RouteRolesId { get; set; }
        public RouteInfo RouteInfo { get; set; }
        public RoleInfo RoleInfo { get; set; }
    }

    public class Meta
    {
        [Key]
        public string MetaId { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public bool Affix { get; set; }
        public bool NoCache { get; set; }

        public List<RouteRole> RouteRoles { get; set; }

        //使用getter轉換資料
        public List<string> Roles
        {
            get
            {
                var temp = new List<string>();
                if (RouteRoles != null)
                {
                    foreach (var item in RouteRoles)
                    {
                        if(item!=null) temp.Add(item.RoleInfo.Name);
                    }
                }

                return temp; 
            }
        }

    }
}

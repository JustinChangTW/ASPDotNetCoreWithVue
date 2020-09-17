using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class DefaultDbContext:DbContext
    {
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options):base(options)
        {
        }

        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<RoleInfo> RoleInfo { get; set; }
        public DbSet<AuthInfo> AuthInfo { get; set; }
        public DbSet<RouteInfo> RouteInfo { get; set; }
    }
}

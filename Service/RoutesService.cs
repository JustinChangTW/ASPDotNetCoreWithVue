using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public  class RoutesService
    {
        private DefaultDbContext _dbContext;
        public RoutesService(DefaultDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<RouteInfo> Get()
        {
            var result = _dbContext.RouteInfo.
                Include("Children.Meta.RouteRoles.RoleInfo").
                Include("Children.Children.Meta.RouteRoles.RoleInfo").
                FirstOrDefault(x => x.RouteId == "0").Children.AsQueryable().Include(x=>x.Children).AsQueryable();
            _dbContext.RouteInfo.Include(x => x.Children);

            var d = result.ToListAsync();
            return result;
        }
    }
}

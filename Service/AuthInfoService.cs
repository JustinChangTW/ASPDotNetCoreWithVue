using Data;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Service
{
    public class AuthInfoService
    {
        private readonly DefaultDbContext _dbContext;

        public AuthInfoService(DefaultDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string LoginAuth(AuthInfo auth)
        {
            var authInfo = _dbContext.AuthInfo.FirstOrDefault(x => x.UserName == auth.UserName && x.Password == auth.Password);
            if (authInfo != null)
            {
                authInfo.Token = GetToke(auth);
                _dbContext.SaveChanges();
            }
            return authInfo?.Token;
        }
        public AuthInfo GetAuth(string token)
        {
            return _dbContext.AuthInfo.Include(x => x.UserInfo.Roles).FirstOrDefault(x => x.Token == token);
        }
        private string GetToke(AuthInfo auth)
        {
            return Guid.NewGuid().ToString();
        }

    }
}

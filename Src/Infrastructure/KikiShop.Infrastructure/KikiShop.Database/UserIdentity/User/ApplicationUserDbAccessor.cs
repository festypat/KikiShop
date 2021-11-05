using KikiShop.Infrastructure.KikiShop.Database.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KikiShop.Infrastructure.KikiShop.Database.UserIdentity.User
{
    public interface IApplicationUserDbAccessor
    {
        Task<ApplicationUser> GetUserByEmail(string email);
    }

    public class ApplicationUserDbAccessor : IApplicationUserDbAccessor
    {
        private readonly IdentityContext _dbContext;

        public ApplicationUserDbAccessor(IdentityContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApplicationUser> GetUserByEmail(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(c => c.Email == email);
        }
    }
}

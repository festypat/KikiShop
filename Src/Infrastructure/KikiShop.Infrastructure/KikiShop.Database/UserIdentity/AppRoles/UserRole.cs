using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KikiShop.Infrastructure.KikiShop.Database.UserIdentity.AppRoles
{
    public class UserRole : IdentityRole<Guid>
    {
        public UserRole()
        {
            this.Id = Guid.NewGuid();
        }

        public UserRole(string name)
           : this()
        {
            this.Name = name;
        }
    }
}

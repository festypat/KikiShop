using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KikiShop.Infrastructure.KikiShop.Database.UserIdentity.Jwt
{
    public interface IJwtService
    {
        Task<string> GenerateJwt(string email);
    }
}

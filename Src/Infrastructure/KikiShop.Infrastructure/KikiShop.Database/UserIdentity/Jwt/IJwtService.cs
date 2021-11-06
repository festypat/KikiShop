using System.Threading.Tasks;

namespace KikiShop.Infrastructure.KikiShop.Database.UserIdentity.Jwt
{
    public interface IJwtService
    {
        Task<string> GenerateJwt(string email);
    }
}

using Microsoft.AspNetCore.Identity;

namespace BulkyAPI.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, IList<string> roles);

    }
}

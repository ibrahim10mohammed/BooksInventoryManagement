
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
namespace BooksInventoryManagement.Domain.Repository
{
    public interface IJwtProvider
    {
        string GenerateToken(IdentityUser user, IList<string> roles);
        public string GenerateRefreshToken();
    }
}

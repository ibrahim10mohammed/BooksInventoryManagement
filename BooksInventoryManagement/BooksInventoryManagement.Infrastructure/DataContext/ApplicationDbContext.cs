using BooksInventoryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BooksInventoryManagement.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<Microsoft.AspNetCore.Identity.IdentityUser>
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}

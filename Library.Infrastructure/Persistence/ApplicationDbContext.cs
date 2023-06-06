using Library.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, AppRole, int
        ,IdentityUserClaim<int>, AppUserRole,IdentityUserLogin<int>,IdentityRoleClaim<int>,
        IdentityUserToken<int>>
    {
        public ApplicationDbContext(DbContextOptions options): base(options)
        {
        }
    }
}

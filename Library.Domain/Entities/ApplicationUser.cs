using Microsoft.AspNetCore.Identity;

namespace Library.Domain.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        public List<Book> Books { get; set; }
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}

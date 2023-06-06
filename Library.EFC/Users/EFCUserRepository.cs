using Library.Domain.Entities;
using Library.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Library.EFC.Users
{
    public class EFCUserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public EFCUserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApplicationUser> DeleteUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            return user;
        }

        public async Task<List<ApplicationUser>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<ApplicationUser> GetUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user != null)
            {
                return user;
            }
            return user;
        }

        public async Task<ApplicationUser> RegisterUser(ApplicationUser user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<ApplicationUser> LoginUser(ApplicationUser user)
        {
            var loginUser = await _context.Users.SingleOrDefaultAsync(x => x.UserName == user.UserName);
            return loginUser;

        }

        public async Task<ApplicationUser> UpdateUser(int id, ApplicationUser user)
        {
            var updatingUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (updatingUser != null)
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }
            return user;
        }

        public async Task<bool> UserNameExists(string userName)
        {
            return await _context.Users.AnyAsync(x => x.UserName == userName.ToLower());

        }

        public async Task<ApplicationUser> GetUserByUserName(string userName)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);
            return user;
        }
    }
}

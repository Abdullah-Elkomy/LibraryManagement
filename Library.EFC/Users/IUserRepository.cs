using Library.Domain.Entities;

namespace Library.EFC.Users
{
    public interface IUserRepository
    {
        Task<ApplicationUser> RegisterUser(ApplicationUser user);
        Task<ApplicationUser> LoginUser(ApplicationUser user);


        Task<ApplicationUser> GetUser(int id);
        Task<List<ApplicationUser>> GetAllUsers();
        Task<ApplicationUser> UpdateUser(int id, ApplicationUser user);
        Task<ApplicationUser> DeleteUser(int id);
        Task<bool> UserNameExists(string userName);
        Task<ApplicationUser> GetUserByUserName(string userName);
    }
}

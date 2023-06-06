using Library.Application.Users.Dtos;
using Library.Domain.Entities;

namespace Library.Application.Users
{
    public interface IUserService
    {
        Task<UserDto> RegisterUser(RegisterDto registerDto);
        Task<UserDto> LoginUser(LoginDto loginDto);

        Task<ApplicationUser> GetUserByEmail(string email);

        Task<ApplicationUser> GetUser(int id);
        Task<List<ApplicationUser>> GetAllUsers();
        Task<ApplicationUser> UpdateUser(int id, ApplicationUser user);
        Task<ApplicationUser> DeleteUser(int id);
        Task<bool> UserNameExists(string userName);
    }
}

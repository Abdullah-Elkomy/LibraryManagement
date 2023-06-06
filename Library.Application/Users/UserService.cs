using Library.Application.Token;
using Library.Application.Users.Dtos;
using Library.Domain.Entities;
using Library.EFC.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        public UserService(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }
        public Task<ApplicationUser> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ApplicationUser>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto> LoginUser(LoginDto loginDto)
        {
            var userLogin = await _userRepository.GetUserByUserName(loginDto.UserName);
            if (userLogin == null)
                throw new ValidationException("Invalid UserName");
          
            return new UserDto
            {
                UserName = userLogin.UserName,
                Token = await _tokenService.CreateToken(userLogin)
            };
        }

        public async Task<UserDto> RegisterUser(RegisterDto registerDto)
        {
            if (await UserNameExists(registerDto.UserName))
                throw new ValidationException("UserName allready exist");

            using var hmac = new HMACSHA512();
            var user = new ApplicationUser();
            user.UserName = registerDto.UserName;
           
            var addedUser = await _userRepository.RegisterUser(user);
            return new UserDto
            {
                UserName = addedUser.UserName,
                Token = await _tokenService.CreateToken(addedUser)
            };
        }

        public Task<ApplicationUser> UpdateUser(int id, ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UserNameExists(string userName)
        {
            return await _userRepository.UserNameExists(userName);

        }
    }
}

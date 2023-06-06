using Library.Application.Users;
using Library.Application.Users.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.HttpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;


        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> RegisterAsync(RegisterDto registerDto)
        {
            return await _userService.RegisterUser(registerDto);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> LoginAsync(LoginDto loginDto)
        {
            return await _userService.LoginUser(loginDto);

        }
    }
}

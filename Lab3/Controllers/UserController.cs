using Application.IServices;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab3.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController (IUserService userService) : Controller
    {
        private readonly IUserService _userService = userService;


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]  LoginRequest request)
        {
            int userIdLogin = await _userService.CheckUser(request.UserName, request.Password);
            if (userIdLogin == -1)
            {
                return BadRequest("Invalid username or password");
            }
            HttpContext.Session.SetString("User", userIdLogin.ToString());
            return Ok("Login success");
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Remove("User");
            return Ok("Logout success");
        }
    }

    public class LoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

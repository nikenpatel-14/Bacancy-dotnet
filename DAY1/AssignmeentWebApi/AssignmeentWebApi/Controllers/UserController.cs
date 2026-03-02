using AssignmeentWebApi.DTOs;
using AssignmeentWebApi.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssignmeentWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterUser(UserDTO dto)
        {
            var user = await _userService.RegisterAsync(dto);
            if (user == null)
            {
                return BadRequest("User already exists");
            }

            return Ok(user);
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginUser(UserLoginDTO dto)
        {
            var user = await _userService.LoginAsync(dto);

            if (user == null)
            {
                return BadRequest("Invalid Credentials");
            }

            return Ok(user);
        }
        [HttpGet]
        [Route("admin")]
        [Authorize(Roles = "admin")]
        //[Authorize(Policy ="AdminOnly")]
        public ActionResult AdminService()
        {
            return Ok("Admin Service Granted.");
        }

        [HttpGet]
        [Route("Middleware")]
        public IActionResult CustomMiddleware()
        {
            throw new Exception("check exception");
        }
    }
}

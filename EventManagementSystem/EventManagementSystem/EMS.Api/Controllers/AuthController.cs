using EventManagementSystem.EMS.Application.DTOs;
using EventManagementSystem.EMS.Application.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementSystem.EMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService service;
        public AuthController(IAuthService _service)
        {
            service = _service;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegistrationDTO user)
        {
            await service.RegisterUser(user);
            return Ok(user);

        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDTO user)
        {
            var result = await service.LoginUser(user);
            return Ok(result);
        }

    }
}

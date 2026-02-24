using AssignmeentWebApi.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AssignmeentWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LifeTimeController : ControllerBase
    {
        private readonly IGuidService _service;
        public LifeTimeController(IGuidService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = new
            {  
                FirstTime = _service.getId(),
                SecondTime = _service.getId() };
            return Ok(result);
        }

    }
}

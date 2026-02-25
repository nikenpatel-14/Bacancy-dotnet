using AssignmeentWebApi.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AssignmeentWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LifeTimeController : ControllerBase
    {
        private readonly ITransientGuidService _Ts1;
        private readonly ITransientGuidService _Ts2;
        private readonly IScoppedGuidService _Ss1;
        private readonly IScoppedGuidService _Ss2;
        private readonly ISingletonGuidService _SINs1;
        private readonly ISingletonGuidService _SINs2;
        public LifeTimeController(ITransientGuidService s1, ITransientGuidService s2,
                                  IScoppedGuidService s3, IScoppedGuidService s4,
                                  ISingletonGuidService s5, ISingletonGuidService s6  )
        {
            _Ts1 = s1;
            _Ts2 = s2;
            _Ss1 = s3;
            _Ss2 = s4;
            _SINs1 = s5;
            _SINs2 = s6;

        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = new
            {  
                FirstTransient = _Ts1.getId(),
                SecondTransient = _Ts2.getId(),
                FirstScopped = _Ss1.getId(),
                SecondScopped = _Ss2.getId(),
                FirstSingleton = _SINs1.getId(),
                SecondSingleton = _SINs2.getId()
            };
            return Ok(result);
        }

    }
}

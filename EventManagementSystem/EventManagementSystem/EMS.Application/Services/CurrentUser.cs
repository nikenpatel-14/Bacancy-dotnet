using EventManagementSystem.EMS.Application.Services.Interface;
using System.Security.Claims;

namespace EventManagementSystem.EMS.Application.Services
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IHttpContextAccessor accessor;
        public CurrentUser(IHttpContextAccessor _accessor)
        {
            accessor = _accessor;
        }
        public int UserId
        {
            get
            {
                var userId = accessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                return userId!=null?int.Parse(userId):0;
            }
        }
        
    }
}

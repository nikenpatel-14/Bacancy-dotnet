using EventManagementSystem.EMS.Domain.Entity;

namespace EventManagementSystem.EMS.Application.Services.Interface
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}

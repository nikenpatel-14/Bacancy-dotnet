using EventManagementSystem.EMS.Domain.Entity;

namespace EventManagementSystem.EMS.Infrastructure.Repository.Interface
{
    public interface IAuthRepository
    {
        Task<User> getUserByEmail(string email);
        Task registerUser(User user);

    }
}

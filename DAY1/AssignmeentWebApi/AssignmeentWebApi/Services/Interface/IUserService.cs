using AssignmeentWebApi.DTOs;
using AssignmeentWebApi.Repository.Model;

namespace AssignmeentWebApi.Services.Interface
{
    public interface IUserService
    {
        public Task<User?> RegisterAsync(UserDTO dto);
        public Task<string?> LoginAsync(UserLoginDTO dto);
    }
}

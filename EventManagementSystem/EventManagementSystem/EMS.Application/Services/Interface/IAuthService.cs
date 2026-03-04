using EventManagementSystem.EMS.Application.DTOs;

namespace EventManagementSystem.EMS.Application.Services.Interface
{
    public interface IAuthService
    {
        Task RegisterUser(UserRegistrationDTO userDTO);
        Task<AuthResponseDTO> LoginUser(UserLoginDTO userDTO);

    }
}

using EventManagementSystem.EMS.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace EventManagementSystem.EMS.Application.DTOs
{
    public class UserRegistrationDTO
    {
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } 
        public UserRole Role { get; set; }
    }
}

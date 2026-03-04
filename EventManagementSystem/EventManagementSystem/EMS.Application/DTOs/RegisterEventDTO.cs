using System.ComponentModel.DataAnnotations;

namespace EventManagementSystem.EMS.Application.DTOs
{
    public class RegisterEventDTO
    {
        [Required]
        public string EventTitle { get; set; }
    }
}

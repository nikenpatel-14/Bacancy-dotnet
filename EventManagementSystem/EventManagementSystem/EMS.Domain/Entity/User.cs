using EventManagementSystem.EMS.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace EventManagementSystem.EMS.Domain.Entity
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
     
        public string UserName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        public UserRole Role { get; set; }

        public List<Event> OrganizedEvents { get; set; } = new List<Event>();
        public List<EventRegistration> EventRegistrations { get; set; } = new List<EventRegistration>();
    }
}

using EventManagementSystem.EMS.Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManagementSystem.EMS.Domain.Entity
{
    public class EventRegistration
    {

        public int UserId { get; set; }
        public User User { get; set; }
   
        public int EventId {  get; set; }
        public Event Event { get; set; }

        public DateTime RegisteredAt { get; set; }

        public RegistrationStatus RegistrationStatus { get; set; }
    }
}

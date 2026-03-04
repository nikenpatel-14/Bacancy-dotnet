using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace EventManagementSystem.EMS.Domain.Entity
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        public string EventTitle { get; set; } = string.Empty;

        public string EventDescription { get; set; } = string.Empty;

        public DateOnly EventDate { get; set; } 

        public string EventLocation { get; set; }= string.Empty;


        public int Capacity { get; set; }


        public List<EventRegistration> EventRegistrations { get; set; } = new List<EventRegistration>();

        public int OrganizerId { get; set; }

        public User Organizer { get; set; }
    }
}

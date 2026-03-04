using System.ComponentModel.DataAnnotations;

namespace EventManagementSystem.EMS.Application.DTOs
{
    public class EventDTO
    {

        [Required]
        [StringLength(100)]
        public string EventTitle { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 50)]
        public string EventDescription { get; set; }

        public DateOnly EventDate { get; set; }

        [Required]
        public string EventLocation { get; set; } 
        public int Capacity { get; set; }

    }
}

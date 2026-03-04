namespace EventManagementSystem.EMS.Application.DTOs
{
    public class ViewRegistrationDTO
    {
           public int UserId { get; set; }
           public string UserName { get; set; }
           public int EventId { get; set; }
           public string EventTitle { get; set; }

           public DateTime RegisteredAt { get; set; }

           public string RegistrationStatus { get; set; }
        
    }
}

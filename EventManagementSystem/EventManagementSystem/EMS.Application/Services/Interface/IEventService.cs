using EventManagementSystem.EMS.Application.DTOs;

namespace EventManagementSystem.EMS.Application.Services.Interface
{
    public interface IEventService
    {
        Task<EventDTO> createEvent(EventDTO eventDTO);
        Task updateEvent(EventDTO eventDTO,int Id);

        Task updateOrganizerEvent(EventDTO eventDTO, int id);
        Task<bool> deleteEvent(int id);

        Task<List<EventDTO>> viewAllEvent();

        Task registerEvent(RegisterEventDTO register);
        Task cancelRegistartion(int EventId);


        Task<List<ViewRegistrationDTO>> GetRegistrations(string role);






    }
}

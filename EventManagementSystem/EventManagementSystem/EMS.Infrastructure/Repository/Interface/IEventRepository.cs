using EventManagementSystem.EMS.Application.DTOs;
using EventManagementSystem.EMS.Domain.Entity;

namespace EventManagementSystem.EMS.Infrastructure.Repository.Interface
{
    public interface IEventRepository
    {
        Task createEvent(Event eventObj);
        Task updateEvent(Event eventObj,Event Existing);
        Task<bool> deleteEvent(Event eventObj);

        Task<List<Event>> viewAllEvents();
        Task<Event> getEventById(int id);
        Task<Event> getEventByTitle(string title);
        Task eventRegistration(EventRegistration registration);
        Task eventRegistrationCancelled(int UserId, int EventId);

        Task<List<ViewRegistrationDTO>> GetAllRegistrations();
        Task<List<ViewRegistrationDTO>> GetOrganizerRegistrations(int organizerId);
    }
}

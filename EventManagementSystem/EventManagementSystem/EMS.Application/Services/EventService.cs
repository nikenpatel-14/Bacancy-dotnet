using AutoMapper;
using EventManagementSystem.EMS.Application.DTOs;
using EventManagementSystem.EMS.Application.Services.Interface;
using EventManagementSystem.EMS.Domain.Entity;
using EventManagementSystem.EMS.Domain.Enum;
using EventManagementSystem.EMS.Infrastructure.Repository.Interface;

namespace EventManagementSystem.EMS.Application.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository repository;
        private readonly IMapper mapper;
        private readonly ICurrentUser current;
        public EventService(IEventRepository _repository,IMapper _mapper,ICurrentUser _current)
        {
            repository = _repository;
            mapper = _mapper;
            current = _current;
        }
        public async Task<EventDTO> createEvent(EventDTO eventDTO)
        {
            var obj = mapper.Map<Event>(eventDTO);
            obj.OrganizerId = current.UserId;
            await repository.createEvent(obj);
            return eventDTO;
        }
        public async Task updateEvent(EventDTO eventDTO, int Id)
        {
            var obj = mapper.Map<Event>(eventDTO);
            obj.OrganizerId = current.UserId;
            var existingEvent = await repository.getEventById(Id);
            if(existingEvent == null)
            {
                throw new Exception("Event Does not exist");
            }
            await repository.updateEvent(obj,existingEvent);
        }

        public async Task updateOrganizerEvent(EventDTO eventDTO, int id)
        {
            var existingEvent = await repository.getEventById(id);
            var OrganizerId = current.UserId;
            if (existingEvent == null)
            {
                throw new Exception("Event Does not exist");
            }
            if (OrganizerId != existingEvent.OrganizerId)
            {
                throw new Exception("This event is not Organized by current user");
            }
            var obj = mapper.Map<Event>(eventDTO);
            await repository.updateEvent(obj, existingEvent);

        }
        public async Task<bool> deleteEvent(int id)
        {
            var obj = await repository.getEventById(id);
            return await repository.deleteEvent(obj);
        }

        public async Task<List<EventDTO>> viewAllEvent()
        {
            var obj = await repository.viewAllEvents();
            return mapper.Map<List<EventDTO>>(obj);
        }

        public async Task registerEvent(RegisterEventDTO register)
        {
            var EventObj = await repository.getEventByTitle(register.EventTitle);
            var result = new EventRegistration
            {
                EventId = EventObj.EventId,
                UserId = current.UserId,
                RegisteredAt = DateTime.Now,
                RegistrationStatus = RegistrationStatus.Enrolled
            };
            
            await repository.eventRegistration(result);
            
        }
        public async Task cancelRegistartion(int EventId)
        {
            int userid = current.UserId;
            await repository.eventRegistrationCancelled(userid, EventId);
            
        }
        public async Task<List<ViewRegistrationDTO>> GetRegistrations(string role)
        {
            if (role == "Admin")
            {
                return await repository.GetAllRegistrations();
            }

            int userId = current.UserId;
            return await repository.GetOrganizerRegistrations(userId);
            
        }
    }
}

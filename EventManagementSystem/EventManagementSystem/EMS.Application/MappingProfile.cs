using AutoMapper;
using EventManagementSystem.EMS.Application.DTOs;
using EventManagementSystem.EMS.Domain.Entity;

namespace EventManagementSystem.EMS.Application


{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Event, EventDTO>();
            CreateMap<EventDTO, Event>();
            CreateMap<UserRegistrationDTO, User>();

        }
    }
}

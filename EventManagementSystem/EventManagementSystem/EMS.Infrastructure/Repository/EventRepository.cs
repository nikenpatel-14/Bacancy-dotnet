using EventManagementSystem.EMS.Application.DTOs;
using EventManagementSystem.EMS.Domain.Entity;
using EventManagementSystem.EMS.Domain.Enum;
using EventManagementSystem.EMS.Infrastructure.Data;
using EventManagementSystem.EMS.Infrastructure.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace EventManagementSystem.EMS.Infrastructure.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly AppDbContext _dbContext;
        public EventRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task createEvent(Event eventObj)
        {
            await _dbContext.Events.AddAsync(eventObj);
            await _dbContext.SaveChangesAsync();
           
        }
        public async Task updateEvent(Event eventObj,Event Existing)
        {
            Existing.EventTitle = eventObj.EventTitle;
            Existing.EventDate = eventObj.EventDate;
            Existing.EventDescription = eventObj.EventDescription;
            Existing.EventLocation = eventObj.EventLocation;
            Existing.Capacity = eventObj.Capacity;
            
            await _dbContext.SaveChangesAsync();

        }
        public async Task<bool> deleteEvent(Event eventObj)
        {
            _dbContext.Events.Remove(eventObj);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<List<Event>> viewAllEvents() 
        {
            return await _dbContext.Events.ToListAsync();
        }

        public async Task<Event> getEventById(int id)
        {
           return await _dbContext.Events.FirstOrDefaultAsync(x => x.EventId == id);
        }
        public async Task<Event> getEventByTitle(string title)
        {
            return await _dbContext.Events.FirstOrDefaultAsync(x => x.EventTitle == title);
        }

        public async Task eventRegistration(EventRegistration registration)
        {
            await _dbContext.EventRegistrations.AddAsync(registration);
           
            await _dbContext.SaveChangesAsync();
        }
        public async Task eventRegistrationCancelled(int UserId,int EventId)
        {
            var registration = await _dbContext.EventRegistrations
                    .FirstOrDefaultAsync(x => x.UserId == UserId && x.EventId == EventId);

            if (registration == null)
                throw new Exception("Registration not found");

            registration.RegistrationStatus = RegistrationStatus.Cancelled;

            await _dbContext.SaveChangesAsync();

        }
        public async Task<List<ViewRegistrationDTO>> GetAllRegistrations()
        {
            return await _dbContext.EventRegistrations
                .Include(x => x.User)
                .Include(x => x.Event)
                .AsSplitQuery()
                .Select(x => new ViewRegistrationDTO
                {
                    UserId = x.UserId,
                    UserName = x.User.UserName,
                    EventId = x.EventId,
                    EventTitle = x.Event.EventTitle,
                    RegisteredAt = x.RegisteredAt,
                    RegistrationStatus = x.RegistrationStatus.ToString()
                })
                .ToListAsync();
        }

        public async Task<List<ViewRegistrationDTO>> GetOrganizerRegistrations(int organizerId)
        {
            return await _dbContext.EventRegistrations
                .Include(x => x.User)
                .Include(x => x.Event)
                .Where(x => x.Event.OrganizerId == organizerId)
                .AsSplitQuery()
                .Select(x => new ViewRegistrationDTO
                {
                    UserId = x.UserId,
                    UserName = x.User.UserName,
                    EventId = x.EventId,
                    EventTitle = x.Event.EventTitle,
                    RegisteredAt = x.RegisteredAt,
                    RegistrationStatus = x.RegistrationStatus.ToString()
                })
                .ToListAsync();
        }
    }
}

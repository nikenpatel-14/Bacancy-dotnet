using EventManagementSystem.EMS.Application.DTOs;
using EventManagementSystem.EMS.Application.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using System.Security.Claims;

namespace EventManagementSystem.EMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService service;
        public EventController(IEventService _service)
        {
            service = _service;
        }

        [EnableRateLimiting("UserRateLimit")]
        [HttpPost("CreateEvent")]
        [Authorize(Roles = "Admin,Organizer")]
        public async Task<IActionResult> CreateEvent(EventDTO eventDTO)
        {
            var result = await service.createEvent(eventDTO);
            return Created();
        }

        [HttpPatch("UpdateEvent/{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateEvent(EventDTO eventDTO, int id)
        {
            await service.updateEvent(eventDTO, id);
            return Ok();
        }
        [HttpPatch("UpdateOrganizedEvent/{id:int}")]
        [Authorize(Roles ="Admin,Organizer")]
        public async Task<IActionResult> UpdateOrganizedEvent(EventDTO eventDTO,int id)
        {
            await service.updateOrganizerEvent(eventDTO, id);
            return Ok();
        }
        [HttpDelete("DeleteEvent/{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            
            var deleted = await service.deleteEvent(id);
            return NoContent();
        }
        [HttpGet("ViewAll")]
        [Authorize]
        public async Task<IActionResult> GetAllEvents()
        {
            var result = await service.viewAllEvent();
            return Ok(result);
        }

        [EnableRateLimiting("UserRateLimit")]
        [HttpPost("RegisterEvent")]
        [Authorize]
        public async Task<IActionResult> RegisterForEvent(RegisterEventDTO register)
        {
            await service.registerEvent(register);
            return Ok("registered for event succesfully");
        }

        [EnableRateLimiting("UserRateLimit")]
        [HttpPatch("CancelRegistration")]
        [Authorize]
        public async Task<IActionResult> CancelRegistration(CancelRegistrationDTO dto)
        {
            await service.cancelRegistartion(dto.EventId);
            return Ok("Registration cancelled successfully");
        }

        [EnableRateLimiting("UserRateLimit")]
        [HttpGet("ViewAllRegistration")]
        [Authorize(Roles ="Admin,Organizer")]
        public async Task<IActionResult> GetAllRegistartions()
        {
            string role = User.FindFirst(ClaimTypes.Role).Value;
            var result = await service.GetRegistrations(role);
            return Ok(result);
        }
    }
}

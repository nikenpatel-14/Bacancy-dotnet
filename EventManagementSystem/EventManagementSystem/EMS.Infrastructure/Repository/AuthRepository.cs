using EventManagementSystem.EMS.Domain.Entity;
using EventManagementSystem.EMS.Infrastructure.Data;
using EventManagementSystem.EMS.Infrastructure.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace EventManagementSystem.EMS.Infrastructure.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDbContext _context;

        public AuthRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> getUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);

        }
        public async Task registerUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}

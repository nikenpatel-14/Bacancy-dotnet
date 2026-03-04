using Microsoft.EntityFrameworkCore;
using EventManagementSystem.EMS.Domain.Entity;
using EventManagementSystem.EMS.Infrastructure.Data.Configuration;

namespace EventManagementSystem.EMS.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventRegistration> EventRegistrations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EventRegistrationConfiguration());
            modelBuilder.ApplyConfiguration(new EventConfiguration());
        }

    }
}

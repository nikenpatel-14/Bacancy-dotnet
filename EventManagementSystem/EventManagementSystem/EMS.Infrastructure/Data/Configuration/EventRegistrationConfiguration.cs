using EventManagementSystem.EMS.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManagementSystem.EMS.Infrastructure.Data.Configuration
{
    public class EventRegistrationConfiguration : IEntityTypeConfiguration<EventRegistration>
    {
        public void Configure(EntityTypeBuilder<EventRegistration> builder)
        {
            builder.HasKey(er => new { er.UserId, er.EventId });

            builder.HasOne(er => er.User)
                   .WithMany(er => er.EventRegistrations)
                   .HasForeignKey(er => er.UserId)
                   .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(er => er.Event)
                   .WithMany(er => er.EventRegistrations)
                   .HasForeignKey(er => er.EventId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

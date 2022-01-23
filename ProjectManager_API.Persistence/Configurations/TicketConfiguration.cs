using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager_API.Domain.Entities;

namespace ProjectManager_API.Persistence.Configurations; 

public class TicketConfiguration : IEntityTypeConfiguration<Ticket> {
    public void Configure(EntityTypeBuilder<Ticket> builder) {
        builder.Property(e => e.TicketState)
            .IsRequired();
        builder.HasKey(e => e.TicketId);
        // builder.Property(e => e.Project)
            // .IsRequired();
        builder.Property(e => e.TicketName)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(e => e.DateCreated).IsRequired();
    }
}

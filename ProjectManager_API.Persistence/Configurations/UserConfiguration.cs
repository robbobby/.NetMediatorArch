using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager_API.Domain.Entities;

namespace ProjectManager_API.Persistence.Configurations; 

public class UserConfiguration : IEntityTypeConfiguration<User> {
    public void Configure(EntityTypeBuilder<User> builder) {
        builder.Property(e => e.FirstName)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(e => e.LastName)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(e => e.Email)
            .IsRequired();
        builder.Property(e => e.Password)
            .IsRequired()
            .HasMaxLength(50);
        builder.HasKey(e => e.UserId);
        // builder.HasMany(u => u.Projects).WithOne(p => p.OwnerUser).HasForeignKey("ProjectId");
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager_API.Domain.Entities;

namespace ProjectManager_API.Persistence.Configurations; 

public class ProjectConfiguration : IEntityTypeConfiguration<Project> {
    public void Configure(EntityTypeBuilder<Project> builder) {
        
        builder.Property(p => p.ProjectName)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(p => p.OwnerUser)
            .IsRequired();
        builder.Property(p => p.DateCreated)
            .IsRequired();
        builder.HasKey(p => p.ProjectId);
        builder.HasMany(e => e.UsersInProject);
        builder.Ignore(p => p.OwnerUser);
        builder.HasOne(p => p.OwnerUser);
    }
}

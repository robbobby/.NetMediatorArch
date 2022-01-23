using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager_API.Domain.Entities;

namespace ProjectManager_API.Persistence.Configurations; 

public class UsersInProjectConfiguration : IEntityTypeConfiguration<UsersInProject> {
    public void Configure(EntityTypeBuilder<UsersInProject> builder) {
        builder.HasOne(u => u.User).WithMany(us => us.UsersInProjects).HasForeignKey(usersInProject => usersInProject.UserId);
        builder.HasOne(u => u.Project).WithMany(us => us.UsersInProjects).HasForeignKey(usersInProject => usersInProject.ProjectId);
    }
}

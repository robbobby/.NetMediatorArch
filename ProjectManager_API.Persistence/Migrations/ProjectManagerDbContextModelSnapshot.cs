﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectManager_API.Persistence;

#nullable disable

namespace ProjectManager_API.Persistence.Migrations
{
    [DbContext(typeof(ProjectManagerDbContext))]
    partial class ProjectManagerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ProjectManager_API.Domain.Entities.Project", b =>
                {
                    b.Property<Guid>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("OwnerUserUserId")
                        .HasColumnType("char(36)");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("ProjectId");

                    b.HasIndex("OwnerUserUserId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("ProjectManager_API.Domain.Entities.Ticket", b =>
                {
                    b.Property<Guid>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("Project")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("char(36)");

                    b.Property<string>("TicketName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("TicketState")
                        .HasColumnType("int");

                    b.Property<Guid?>("UserAssignedId")
                        .HasColumnType("char(36)");

                    b.HasKey("TicketId");

                    b.HasIndex("UserAssignedId");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("ProjectManager_API.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ProjectManager_API.Domain.Entities.UsersInProject", b =>
                {
                    b.Property<int>("UsersInProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("ProjectId1")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<int>("UserPermissions")
                        .HasColumnType("int");

                    b.HasKey("UsersInProjectId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("ProjectId1");

                    b.HasIndex("UserId");

                    b.ToTable("UsersInProjects");
                });

            modelBuilder.Entity("ProjectManager_API.Domain.Entities.Project", b =>
                {
                    b.HasOne("ProjectManager_API.Domain.Entities.User", "OwnerUser")
                        .WithMany()
                        .HasForeignKey("OwnerUserUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OwnerUser");
                });

            modelBuilder.Entity("ProjectManager_API.Domain.Entities.Ticket", b =>
                {
                    b.HasOne("ProjectManager_API.Domain.Entities.User", "UserAssigned")
                        .WithMany("TicketsAssigned")
                        .HasForeignKey("UserAssignedId");

                    b.Navigation("UserAssigned");
                });

            modelBuilder.Entity("ProjectManager_API.Domain.Entities.UsersInProject", b =>
                {
                    b.HasOne("ProjectManager_API.Domain.Entities.Project", "Project")
                        .WithMany("UsersInProjects")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectManager_API.Domain.Entities.Project", null)
                        .WithMany("UsersInProject")
                        .HasForeignKey("ProjectId1");

                    b.HasOne("ProjectManager_API.Domain.Entities.User", "User")
                        .WithMany("UsersInProjects")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProjectManager_API.Domain.Entities.Project", b =>
                {
                    b.Navigation("UsersInProject");

                    b.Navigation("UsersInProjects");
                });

            modelBuilder.Entity("ProjectManager_API.Domain.Entities.User", b =>
                {
                    b.Navigation("TicketsAssigned");

                    b.Navigation("UsersInProjects");
                });
#pragma warning restore 612, 618
        }
    }
}

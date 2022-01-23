using Bogus;
using Microsoft.EntityFrameworkCore;
using ProjectManager_API.Domain.Entities;
using ProjectManager_API.Domain.Enums;

namespace ProjectManager_API.Persistence;

public static class SeedData {
    private static readonly List<User> Users = new();
    private static readonly List<Project> Projects = new();
    private static readonly List<Ticket> Tickets = new();

    private static readonly int projectsGenerateCount = 20;
    private static readonly int ticketsGenerateCount = 20;
    private static readonly int usersGenerateCount = 20;

    private static readonly List<Guid> userGuids = new();
    private static readonly List<Guid> ticketGuids = new();
    private static List<Guid> projectGuids = new();

    public static void Seed(ModelBuilder modelBuilder) {
        GenerateAllGuids();
        for (int i = 0; i < usersGenerateCount; i++) {
            modelBuilder.Entity<User>()
                .OwnsMany(u => u.UsersInProjects, a => a.HasData(GenerateNewFakeProject(projectGuids[i])))
                .HasData(GenerateNewFakeUser(userGuids[i]));
        }
    }
    
    public static void NewSeed(ModelBuilder modelBuilder) {
        GenerateAllGuids();
        for (var i = 0; i < usersGenerateCount; i++) {
            modelBuilder.Entity<User>().HasData(GenerateNewFakeUser(userGuids[i]));
            modelBuilder.Entity<User>().OwnsMany(p => p.UsersInProjects).HasData(GenerateNewFakeProject(projectGuids[i]));
        }
        // for (var i = 0; i < projectsGenerateCount; i++) {
            // modelBuilder.Entity<Project>().HasData(GenerateNewFakeProject(projectGuids[i]));
        // }
        // for (var i = 0; i < ticketsGenerateCount; i++) {
            // modelBuilder.Entity<Ticket>().HasData(GenerateNewFakeTicket(ticketGuids[i]));
        // }
    }

    private static void GenerateAllGuids() {
        GenerateGuids(userGuids, usersGenerateCount);
        GenerateGuids(ticketGuids, ticketsGenerateCount);
        GenerateGuids(projectGuids, projectsGenerateCount);
    }

    private static void GenerateGuids(List<Guid> guids, int count) {
        for (int i = 0; i < count; i++)
            guids.Add(Guid.NewGuid());
    }

    private static Project GenerateNewFakeProject(Guid projectGuid) {
        var projectFaker = new Faker<Project>();
        projectFaker.RuleFor(x => x.ProjectName, x => x.Company.CompanyName())
            .RuleFor(x => x.CreatedBy, x => x.Name.FullName())
            // .RuleFor(x => x.OwnerUser, y => Users[new Random().Next(userGuids.Count)])
            .RuleFor(x => x.ProjectId, y => projectGuid);

        var project = projectFaker.Generate();


        var randomUser = Users[new Random().Next(Users.Count)];
        // project.UsersInProject = new();
        // project.OwnerUser = randomUser;

        AddUsersToProject(project);
        Projects.Add(project);
        return project;
    }

    private static void AddUsersToProject(Project project) {
        // List<Guid> listOfUsers = userGuids.Take(5).ToList();
        // for (int i = 0; i < listOfUsers.Count(); i++)
        //     project.UsersInProject?.Add(new UsersInProject() {
        //         User = Users[i],
        //         Project = project,
        //         UserPermissions = UserPermissions.ReadWriteCreate
        //     });
    }

    private static User GenerateNewFakeUser(Guid userGuid) {
        var userFaker = new Faker<User>();
        userFaker.RuleFor(x => x.FirstName, y => y.Name.FirstName())
            .RuleFor(x => x.LastName, y => y.Name.LastName())
            .RuleFor(x => x.Email, y => y.Person.Email)
            .RuleFor(x => x.Password, y => y.Random.Hash())
            .RuleFor(x => x.UserId, async => userGuid);

        var user = userFaker.Generate();

        Users.Add(user);
        return user;
    }

    private static Ticket GenerateNewFakeTicket(Guid ticketGuid) {
        var ticketFaker = new Faker<Ticket>();
        ticketFaker
            .RuleFor(x => x.TicketName, a => a.Lorem.Slug())
            .RuleFor(x => x.DateCreated, a => DateTime.Now)
            .RuleFor(x => x.TicketId, a => ticketGuid)
            .RuleFor(x => x.ProjectId, a => projectGuids[new Random().Next(projectGuids.Count)])
            .RuleFor(x => x.Description, a => a.Lorem.Paragraph());

        Ticket? ticket = ticketFaker.Generate();

        ticket.ProjectId = projectGuids[0];
        Tickets.Add(ticket);
        return ticket;
    }
}

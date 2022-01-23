using Bogus;
using ProjectManager_API.Domain.Entities;

namespace ProjectManager_API.Persistence;

public class NewDataSeeder {
    private readonly ProjectManagerDbContext _dbContext;

    public NewDataSeeder(ProjectManagerDbContext dbContext) {
        _dbContext = dbContext;
        Seed();
    }

    private static readonly List<User> Users = new();
    private static readonly List<Project> Projects = new();
    private static readonly List<Ticket> Tickets = new();

    private static readonly int projectsGenerateCount = 20;
    private static readonly int ticketsGenerateCount = 20;
    private static readonly int usersGenerateCount = 20;

    private static readonly List<Guid> userGuids = new();
    private static readonly List<Guid> ticketGuids = new();
    private static List<Guid> projectGuids = new();

    public void Seed() {
        if (!_dbContext.Projects.Any()) {
            for (var i = 0; i < usersGenerateCount; i++) {
                GenerateNewFakeUser(userGuids[i]);
            }
            _dbContext.Users.AddRange(Users);
            _dbContext.SaveChanges();
        }
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
}

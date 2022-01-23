using AutoMapper;
using MediatR;
using ProjectManager_API.Application.Contracts.Persistence;
using ProjectManager_API.Application.Interfaces.Persistence;
using ProjectManager_API.Domain.Entities;

namespace ProjectManager_API.Application.Features.UserFeatures.Command;

public class CreateUserCommand : IRequest<bool> {
    public string FirstName { get; set; }
    public string Email { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
}

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool> {
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper) {
        _userRepository = userRepository;
        _mapper = mapper;
    }


    public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken) {
        var user = _mapper.Map<User>(request);
        user = await _userRepository.AddAsync(user);

        return user.UserId.ToString().Length > 0;
    }
}

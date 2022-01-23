using AutoMapper;
using MediatR;
using ProjectManager_API.Application.Contracts.Persistence;
using ProjectManager_API.Application.Interfaces.Persistence;
using ProjectManager_API.Domain.Entities;

namespace ProjectManager_API.Application.Features.UserFeatures.Command;

public class UpdateUserCommand : IRequest {
    public Guid UserId { get; set; }
    public string FirstName { get; set; }
    public string Email { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public List<Project>? Projects { get; set; }
    public List<Ticket>? TicketsAssigned { get; set; }
}


public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand> {
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper) {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken) {
        User userToUpdate = await _userRepository.GetByIdAsync(request.UserId);
        _mapper.Map(request, userToUpdate, typeof(UpdateUserCommand), typeof(Ticket));
        return Unit.Value;
    }
}

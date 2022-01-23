using AutoMapper;
using MediatR;
using ProjectManager_API.Application.Contracts.Persistence;
using ProjectManager_API.Application.Interfaces.Persistence;
using ProjectManager_API.Domain.Entities;

namespace ProjectManager_API.Application.Features.TicketFeatures.Command;

public class UpdateTicketCommand : IRequest {
    public Guid TicketId { get; set; }
    public Guid ProjectId { get; set; }
    public string TicketName { get; set; }
    public string? Description { get; set; }
    public DateTime DateCreated { get; set; }
}


public class UpdateTicketCommandHandler : IRequestHandler<UpdateTicketCommand> {
    private readonly ITicketRepository _ticketRepository;
    private readonly IMapper _mapper;

    public UpdateTicketCommandHandler(ITicketRepository ticketRepository, IMapper mapper) {
        _ticketRepository = ticketRepository;
        _mapper = mapper;
    }
    
    public async Task<Unit> Handle(UpdateTicketCommand request, CancellationToken cancellationToken) {
        Ticket taskToUpdate = await _ticketRepository.GetByIdAsync(request.TicketId);
        _mapper.Map(request, taskToUpdate, typeof(UpdateTicketCommand), typeof(Ticket));
        return Unit.Value;
    }
}

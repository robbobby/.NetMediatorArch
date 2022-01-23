using AutoMapper;
using MediatR;
using ProjectManager_API.Application.Contracts.Persistence;
using ProjectManager_API.Application.Interfaces.Persistence;
using ProjectManager_API.Domain.Entities;

namespace ProjectManager_API.Application.Features.TicketFeatures.Command;

public class DeleteTicketCommand : IRequest {
    public Guid TicketId { get; set; }
}


public class DeleteTicketCommandHandler : IRequestHandler<DeleteTicketCommand> {
    private readonly ITicketRepository _ticketRepository;
    private readonly IMapper _mapper;

    public async Task<Unit> Handle(DeleteTicketCommand request, CancellationToken cancellationToken) {
        var ticketToDelete = await _ticketRepository.GetByIdAsync(request.TicketId);
        await _ticketRepository.DeleteAsync(ticketToDelete);
        
        return Unit.Value;
    }

    public DeleteTicketCommandHandler(ITicketRepository ticketRepository, IMapper mapper) {
        _ticketRepository = ticketRepository;
        _mapper = mapper;
    }
}

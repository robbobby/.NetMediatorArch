using AutoMapper;
using MediatR;
using ProjectManager_API.Application.Contracts.Persistence;
using ProjectManager_API.Application.Interfaces.Persistence;
using ProjectManager_API.Domain.Entities;

namespace ProjectManager_API.Application.Features.TicketFeatures.Queries.GetTaskDetail;


public class GetTicketDefailtQuery : IRequest<TicketDetailVm> {
    public Guid Id { get; set; }
}

public class GetTicketDetailQueryHandler : IRequestHandler<GetTicketDefailtQuery, TicketDetailVm> {

    private readonly IAsyncRepository<Ticket> _ticketRepository;

    private readonly IMapper _mapper;

    public GetTicketDetailQueryHandler(IAsyncRepository<Ticket> ticketRepository, IMapper mapper) {
        _ticketRepository = ticketRepository;
        _mapper = mapper;
    }

    public async Task<TicketDetailVm> Handle(GetTicketDefailtQuery request, CancellationToken cancellationToken) {
        Ticket ticket = await _ticketRepository.GetByIdAsync(request.Id);
        TicketDetailVm? ticketDto = _mapper.Map<TicketDetailVm>(ticket);
        return ticketDto;
    }
}

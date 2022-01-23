using AutoMapper;
using MediatR;
using ProjectManager_API.Application.Contracts.Persistence;
using ProjectManager_API.Application.Interfaces.Persistence;
using ProjectManager_API.Domain.Entities;

namespace ProjectManager_API.Application.Features.TicketFeatures.Queries.GetTicketList;


public class GetTicketListQuery : IRequest, IRequest<List<TicketListVm>> {
    
}

public class GetTicketListQueryHandler : IRequestHandler<GetTicketListQuery, List<TicketListVm>> {

    private readonly IAsyncRepository<Ticket> _ticketRepository;
    private readonly IMapper _mapper;

    public GetTicketListQueryHandler(IAsyncRepository<Ticket> ticketRepository, IMapper mapper) {
        _ticketRepository = ticketRepository;
        _mapper = mapper;
    }

    public async Task<List<TicketListVm>> Handle(GetTicketListQuery request, CancellationToken cancellationToken) {
        var allTickets = (await _ticketRepository.GetAllAsListAsync()).OrderBy(x => x.TicketName);

        return _mapper.Map<List<TicketListVm>>(allTickets);
    }
}

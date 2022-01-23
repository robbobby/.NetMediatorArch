using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using ProjectManager_API.Application.Interfaces.Infrastructure;
using ProjectManager_API.Application.Interfaces.Persistence;
using ProjectManager_API.Application.Models.Mail;
using ProjectManager_API.Domain.Entities;

namespace ProjectManager_API.Application.Features.TicketFeatures.Command;

public class CreateTicketCommand : IRequest<Guid> {
    public Guid ProjectId { get; set; }
    public string TicketName { get; set; }
    public string? Description { get; set; }
    public DateTime DateCreated { get; set; }
    public TicketState TicketState { get; set; }
    public User UserAssigned { get; set; }
}

public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, Guid> {
    private readonly ITicketRepository _ticketRepository;
    private readonly IMapper _mapper;
    private readonly IEmailService _emailService;

    public async Task<Guid> Handle(CreateTicketCommand request, CancellationToken cancellationToken) {
        var validator = new CreateTicketCommandValidator(_ticketRepository);
        ValidationResult? validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Count > 0)
            throw new Exceptions.ValidationException(validationResult);

        Ticket? ticket = _mapper.Map<Ticket>(request);
        ticket = await _ticketRepository.AddAsync(ticket);

        var email = new Email() {
            To = "r.hollingworth@hotmail.com",
            Body = $"A ticket was created {request.TicketName}",
            Subject = "A new ticket was created"
        };

        try {
            await _emailService.SendEmail(email);
        } catch (Exception exception) {

        }

        return ticket.TicketId;
    }

    public CreateTicketCommandHandler(ITicketRepository ticketRepository, IMapper mapper, IEmailService emailService) {
        _ticketRepository = ticketRepository;
        _mapper = mapper;
        _emailService = emailService;
    }
}

public class CreateTicketCommandValidator : AbstractValidator<CreateTicketCommand> {
    private readonly ITicketRepository _ticketRepository;

    public CreateTicketCommandValidator(ITicketRepository ticketRepository) {
        _ticketRepository = ticketRepository;
        RuleFor(ticket => ticket.TicketName)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} is required");
        RuleFor(ticket => ticket.DateCreated)
            .NotEmpty().WithMessage("{PropertyName is required")
            .NotNull()
            .GreaterThan(DateTime.Now);
        RuleFor(ticket => ticket)
            .MustAsync(TicketNameAndDateUnique)
            .WithMessage("An event with the same name and date already exists in this project.");
    }

    private async Task<bool> TicketNameAndDateUnique(CreateTicketCommand ticket, CancellationToken token) {
        return !(await _ticketRepository.IsTicketNameAndDateUnique(ticket.ProjectId, ticket.TicketName, ticket.DateCreated));
    }
}

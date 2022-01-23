using AutoMapper;
using ProjectManager_API.Application.Features.ProjectFeatures.Queries.GetProjectDetail;
using ProjectManager_API.Application.Features.ProjectFeatures.Queries.GetProjectList;
// using ProjectManager_API.Application.Features.TicketFeatures.Command;
using ProjectManager_API.Application.Features.TicketFeatures.Queries.GetTicketList;
using ProjectManager_API.Domain.Entities;

namespace ProjectManager_API.Application.Profiles; 

public class MappingProfile : Profile {
    public MappingProfile() {
        CreateProjectProfiles();
        CreateUserProfiles();
        CreateTicketProfiles();
    }
    
    private void CreateTicketProfiles() {
        CreateMap<Ticket, ProjectDetailedVm>();
        CreateMap<Ticket, TicketListVm>();
        CreateMap<Ticket, ProjectTicketDto>();
        // CreateMap<Ticket, CreateTicketCommand>();

    }
    
    private void CreateUserProfiles() {
        throw new NotImplementedException();
    }
    
    private void CreateProjectProfiles() {
        CreateMap<Project, ProjectDetailedVm>();
        CreateMap<Project, ProjectListVm>().ReverseMap();
        CreateMap<Project, ProjectTicketDto>().ReverseMap();
    }
}

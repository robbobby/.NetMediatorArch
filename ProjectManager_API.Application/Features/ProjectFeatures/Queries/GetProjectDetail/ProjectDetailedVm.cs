namespace ProjectManager_API.Application.Features.ProjectFeatures.Queries.GetProjectDetail; 

public class ProjectDetailedVm {
    public Guid ProjectId { get; set; }
    public string ProjectName { get; set; }
    public List<ProjectDetailedVm>? Tickets { get; set; }
}

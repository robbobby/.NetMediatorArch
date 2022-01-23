namespace ProjectManager_API.Domain.Common; 

public class AuditableEntity {
    public string? CreatedBy { get; set; }
    public DateTime DateCreated { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModifiedDate { get; set; }
}

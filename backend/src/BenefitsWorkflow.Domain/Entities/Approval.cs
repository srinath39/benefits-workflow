namespace BenefitsWorkflow.Domain.Entities;


public class Approval
{
    public string ApprovedBy {get;set;}=string.Empty;

    public bool IsApproved {get;set;}
}
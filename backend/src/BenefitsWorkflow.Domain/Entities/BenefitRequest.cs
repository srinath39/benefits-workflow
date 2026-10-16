namespace BenefitsWorkflow.Domain.Entities;

public class BenefitRequest
{
    public int RequestId { get; set; } 

    public string ApplicantName { get; set; } = string.Empty;

    public int Age { get; set; }

    public decimal MonthlySalary { get; set; }

    public bool HasRequiredDocuments { get; set; }
}
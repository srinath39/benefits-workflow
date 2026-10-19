namespace BenefitsWorkflow.Application.DTOs;

public class RequestResponseDto
{
    public int RequestId { get; set; }
    public string ApplicantName { get; set; } = string.Empty;
    public int Age { get; set; }
    public decimal MonthlySalary { get; set; }
    public string Status { get; set; } = string.Empty;
}
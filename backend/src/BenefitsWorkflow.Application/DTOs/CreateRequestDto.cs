namespace BenefitsWorkflow.Application.DTOs;

public class CreateRequestDto
{
    public string ApplicantName { get; set; } = string.Empty;
    public int Age { get; set; }
    public decimal MonthlySalary { get; set; }
}
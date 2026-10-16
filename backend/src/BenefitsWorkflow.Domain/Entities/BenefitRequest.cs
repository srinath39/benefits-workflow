namespace BenefitsWorkflow.Domain.Entities;

public class BenefitRequest
{
    public int RequestId { get; set; }    // auto property 

    public string ApplicantName { get; set; } = string.Empty;

    public int Age { get; set; }

    public decimal MonthlySalary { get; set; }

    public bool HasRequiredDocuments { get; set; }

    public BenefitRequest(int RequestId,int age)  
    {
        this.RequestId=RequestId;
        this.Age=age;

    }
}
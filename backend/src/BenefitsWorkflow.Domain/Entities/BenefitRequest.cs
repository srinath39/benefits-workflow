namespace BenefitsWorkflow.Domain.Entities;

public class BenefitRequest
{
    // public int RequestId { get; set; }    // auto property 

    private int requestId;  // backing field 

    public int RequestId
    {
        get
        {
            return requestId;
        }
        set
        {
            if (value > 40)
            {
                requestId = value;
            }
        }
    }

    public string ApplicantName { get; set; } = string.Empty;

    public int Age { get; set; }

    public decimal MonthlySalary { get; set; }

    public bool HasRequiredDocuments { get; set; }
}
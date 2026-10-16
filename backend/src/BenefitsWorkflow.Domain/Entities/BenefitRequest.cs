namespace BenefitsWorkflow.Domain.Entities;

public class BenefitRequest
{
    public int RequestId { get; set; }    // auto property 

    public string ApplicantName { get; set; } = string.Empty;

    public int Age { get; set; }

    public decimal MonthlySalary { get; set; }

    public void UpdateAge(int age)
    {
        if (age >= 18)
        {
            Age=age;
        }
    }

    public virtual bool IsEligible()
    {
        return Age>=18;
    }

}
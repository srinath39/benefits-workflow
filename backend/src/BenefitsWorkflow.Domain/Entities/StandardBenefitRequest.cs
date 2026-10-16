namespace BenefitsWorkflow.Domain.Entities;


public class StandardBenefitRequest : AbstractBenefitRequest
{
    public override int GetAge()
    {
        return 18;
    }
}
namespace BenefitsWorkflow.Domain.Entities;

public abstract class AbstractBenefitRequest
{
    public string Name {get;set;} =string.Empty;

    public abstract int GetAge();
}
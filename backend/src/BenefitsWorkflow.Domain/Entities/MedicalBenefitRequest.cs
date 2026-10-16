namespace BenefitsWorkflow.Domain.Entities;

public class MedicalBenefitRequest : BenefitRequest
{

    public bool HasRequiredDocuments { get; set; }
    public string MedicalHistory {get;set;} = string.Empty;

    public override bool IsEligible()
    {
        return Age>=18 && HasRequiredDocuments;
    }
}
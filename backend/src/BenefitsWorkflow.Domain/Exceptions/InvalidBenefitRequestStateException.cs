namespace BenefitsWorkflow.Domain.Exceptions;


public class InvalidBenefitRequestStateException :InvalidOperationException
{
    public InvalidBenefitRequestStateException(String erroMsg):base(erroMsg)
    {  }
}
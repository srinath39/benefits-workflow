public class BenefitRequestIdNotFoundException : Exception
{
    public BenefitRequestIdNotFoundException(int id) : base($"The request id {id} is not found")
    {
        // BenefitRequestIdNotFoundException constructor body 
    }
}
using BenefitsWorkflow.Domain.Entities;

BenefitRequest obj = new BenefitRequest(56,34)
{
    ApplicantName = "BenefitsEngine",
    MonthlySalary = 70000,
    HasRequiredDocuments = true

};


string msg=$"the reuest is {obj.RequestId} age is {obj.Age} Application name is {obj.ApplicantName} MonthlySalary is {obj.MonthlySalary} Documets required is {obj.HasRequiredDocuments}";

Console.WriteLine(msg);
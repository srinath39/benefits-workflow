using BenefitsWorkflow.Domain.Entities;

// var medicalBenefitRequest = new MedicalBenefitRequest();

// medicalBenefitRequest.ApplicantName="srinath";
// medicalBenefitRequest.HasRequiredDocuments=true;
// medicalBenefitRequest.MedicalHistory="Has headache";

// Console.WriteLine($"name is {medicalBenefitRequest.ApplicantName} , Documents are present : {medicalBenefitRequest.HasRequiredDocuments} , medical History : {medicalBenefitRequest.MedicalHistory}");


// BenefitRequest request=new BenefitRequest()
// {
//     // HasRequiredDocuments=false,
//     Age=20
// };

// Console.WriteLine(request.IsEligible());


// AbstractBenefitRequest request=new StandardBenefitRequest()
// {
//     Name="Srinath"
// };
// Console.Write($"Name is {request.Name} and Age is {request.GetAge()}");


INotification notification=new MobileNotification();
notification.NotificationDevice();
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


// INotification notification=new MobileNotification();
// notification.NotificationDevice();


// var req1=new BenefitRequest();
// req1.ApplicantName="srinath";
// BenefitRequest.TotalRequests++;


// var req2=new BenefitRequest();
// req2.ApplicantName="Bala";

// Console.WriteLine(req1.ApplicantName);
// Console.WriteLine(req2.ApplicantName);
// Console.WriteLine(BenefitRequest.TotalRequests);

// var request=new BenefitRequest()
// {
//     Age=20,
//     Status=EnumRequestStatus.UnderReview
// };

// Console.WriteLine(request.Status);


var classRequest=new BenefitRequest()
{
    Age=20
};

var classRequest2=classRequest;
classRequest2.Age=30;

Console.WriteLine(classRequest.Age);


var structRequest=new BenefitRequestStruct()
{
    X=10
};

var structRequest2=structRequest;
structRequest2.X=20;

Console.WriteLine(structRequest.X);
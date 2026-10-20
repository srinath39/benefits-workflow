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


// var classRequest=new BenefitRequest()
// {
//     Age=20
// };

// var classRequest2=classRequest;
// classRequest2.Age=30;

// Console.WriteLine(classRequest.Age);


// var structRequest=new BenefitRequestStruct()
// {
//     X=10
// };

// var structRequest2=structRequest;
// structRequest2.X=20;

// Console.WriteLine(structRequest.X);


// var request=new BenefitRequest()
// {
//     RequestId=101,
//     Approval=new Approval()
//     {
//         ApprovedBy="Manager",
//         IsApproved=true
//     }
// };

// Console.WriteLine(request.Approval.ApprovedBy);

// var request=new BenefitRequest("srinath",25,100000m);
// request.UpdateAge(30);

// Console.WriteLine(request.Age);



// List<decimal> salaries=new() {1000m,45000m,35000m,67000m,23000m};
// var filterSalaries=salaries.Where(sal=>sal>30000m).ToList();

// foreach(var d in filterSalaries)
// {
//     Console.WriteLine(d);
// }


// public class Sample
// {
//     public string? name;

//     static void Main()
//     {
//         Sample p=new Sample();
//         Console.WriteLine(p.name);
//     }
// }


// public class Student
// {
//     public int Score;

//     static void Main()
//     {
//         var students = new List<Student>(){
//         new Student(){
//             Score=100
//         },new Student()
//         {
//             Score=200
//         }
//         };
//         Console.Write($"Student average score is {students.Average(s=>s.Score)}");
//     }
// }

// first matched value is returned, if not match the type default value is returned 


List<BenefitRequest> requests = new(){
    new BenefitRequest("srinath",25,60000m),
    new BenefitRequest("balashiva",26,40000m),
    new BenefitRequest("somesh",21,70000m)
};

List<int> marks = new() { 10, 20, 30, 40 };

// All elements
Console.WriteLine(marks.Sum());

Console.WriteLine(requests.Sum(request=>request.MonthlySalary));

Console.WriteLine(requests.Where(request=>request.MonthlySalary>50000).Sum(request=>request.MonthlySalary));

// onyl sum elements >10
// Console.WriteLine(marks.Sum(mark=>mark>10?mark:0));

// this can also be written has 
Console.WriteLine(marks.Where(marks => marks > 10).Sum());
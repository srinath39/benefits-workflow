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


// List<BenefitRequest> requests = new(){
//     new BenefitRequest("srinath",25,60000m),
//     new BenefitRequest("balashiva",26,40000m),
//     new BenefitRequest("somesh",21,70000m)
// };

// List<String> names=requests.Select(request=>request.ApplicantName).ToList();

// foreach(var name in names)
// {
//     Console.WriteLine(name);
// }


// try
// {
//     throw new Exception("Divide by zero exception caught");
// }
// catch(DivideByZeroException ex)
// {
//     Console.WriteLine(ex.Message);
// }catch(Exception ex)
// {
//     Console.WriteLine("General Exception caught");
// }
// finally
// {
//     Console.WriteLine("Runs in both success and failed state");
// // }


// try
// {
//     throw new BenefitRequestIdNotFoundException(23);
// }catch(BenefitRequestIdNotFoundException ex)
// {
//     Console.WriteLine(ex.Message);
// }


// var y=(a:20,name:"srinath",salary:"7000.00");
// Console.WriteLine(y.a);


// var t=(20,"srinath",3000.00);
// Console.WriteLine(t.Item1);


// var (id,name,salary)=t;
// Console.WriteLine(id);
 



// var name="bala";
// var marks = name switch
// {
//     "srinath"=>23.90,
//     "bala"=>45.67,
//     "somesh"=>56.89,
//     _=>67.34
// };
// Console.WriteLine(marks);

var name="bala";
double marks;
switch (name)
{
    case "srinath":
        marks=23.50;
        break;
    case "bala":
        marks=56.78;
        break;
    case "somesh":
        marks=67.89;
        break;
    default:
        marks=78.90;
        break;
}
Console.WriteLine(marks);
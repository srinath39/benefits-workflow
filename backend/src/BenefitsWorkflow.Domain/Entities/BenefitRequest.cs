using BenefitsWorkflow.Domain.Exceptions;

namespace BenefitsWorkflow.Domain.Entities;

public class BenefitRequest
{
    public static int TotalRequests;

    public int RequestId { get; private set; }

    public string ApplicantName { get; private set; }

    public int Age { get; private set; }

    public void UpdateAge(int age)
    {
        if (age < 18)
        {
            throw new ArgumentOutOfRangeException(
                nameof(age),
                "Applicant must be at least 18 years old.");
        }

        Age = age;
    }

    public decimal MonthlySalary { get; private set; }

    public EnumRequestStatus Status { get; private set; }
        = EnumRequestStatus.Submitted;

    public Approval? Approval { get; private set; }

    public BenefitRequest(string applicantName, int age, decimal monthlySalary)
    {
        if (string.IsNullOrWhiteSpace(applicantName))
        {
            throw new ArgumentException(
                "Applicant name is required.",
                nameof(applicantName));
        }

        if (age < 18)
        {
            throw new ArgumentOutOfRangeException(
                nameof(age),
                "Applicant must be at least 18 years old.");
        }

        if (monthlySalary < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(monthlySalary),
                "Monthly salary cannot be negative.");
        }

        ApplicantName = applicantName.Trim();
        Age = age;
        MonthlySalary = monthlySalary;
    }

    public void StartReview()
    {
        if (Status != EnumRequestStatus.Submitted)
        {
            throw new InvalidBenefitRequestStateException(
                "Only submitted requests can enter review.");
        }

        Status = EnumRequestStatus.UnderReview;
    }

    public void Approve()
    {
        if (Status != EnumRequestStatus.UnderReview)
        {
            throw new InvalidBenefitRequestStateException(
                "Only requests under review can be approved.");
        }

        Status = EnumRequestStatus.Approved;
    }

    public void Reject()
    {
        if (Status != EnumRequestStatus.UnderReview)
        {
            throw new InvalidBenefitRequestStateException(
                "Only requests under review can be rejected.");
        }

        Status = EnumRequestStatus.Rejected;
    }

    public void AssignRequestId(int requestId)
    {
        if (RequestId != 0)
        {
            throw new InvalidBenefitRequestStateException(
                "Request ID has already been assigned.");
        }
        if (requestId <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(requestId));
        }
        RequestId = requestId;
    }

}
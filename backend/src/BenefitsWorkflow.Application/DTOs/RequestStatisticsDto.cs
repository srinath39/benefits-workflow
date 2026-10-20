namespace BenefitsWorkflow.Application.DTOs;

public class RequestStatisticsDto
{
    public int TotalRequests { get; set; }

    public int SubmittedRequests { get; set; }

    public int UnderReviewRequests { get; set; }

    public int ApprovedRequests { get; set; }

    public int RejectedRequests { get; set; }
}
using BenefitsWorkflow.Application.DTOs;
using BenefitsWorkflow.Application.Interfaces;
using BenefitsWorkflow.Domain.Entities;

namespace BenefitsWorkflow.Application.Services;

public class BenefitRequestService : IBenefitRequestService
{
    private readonly List<BenefitRequest> _requests = new();

    private int _nextRequestId = 1;

    public RequestResponseDto CreateRequest(CreateRequestDto dto)
    {
        var request = new BenefitRequest(
            dto.ApplicantName,
            dto.Age,
            dto.MonthlySalary);

        request.AssignRequestId(_nextRequestId++);

        _requests.Add(request);

        return MapToResponse(request);
    }

    public RequestResponseDto GetARequestByRequestId(int id)
    {
        int a=10;
        int b=0;
        int c=a/b;
        BenefitRequest? request = _requests.FirstOrDefault(request => request.RequestId == id);

        if (request == null)
        {
            throw new KeyNotFoundException($"request id {id} is not found");
        }
        return MapToResponse(request);
    }

    public List<RequestResponseDto> GetAllRequests()
    {
        return _requests.Select(MapToResponse).ToList();
    }

    public List<RequestResponseDto> GetApprovedRequests()
    {
        return _requests.Where(request => request.Status == EnumRequestStatus.Approved).OrderBy(request => request.ApplicantName).Select(request =>
        {
            return new RequestResponseDto()
            {
                RequestId = request.RequestId,
                ApplicantName = request.ApplicantName,
                Age = request.Age,
                MonthlySalary = request.MonthlySalary,
                Status = request.Status.ToString()
            };
        }).ToList();
    }

    public void StartReview(int id)
    {
        BenefitRequest? request = _requests.FirstOrDefault(request => request.RequestId == id);

        if (request == null)
        {
            throw new KeyNotFoundException($"request id {id} is not found");
        }
        
        request.StartReview();
    }

    public void ApproveReview(int id)
    {
        BenefitRequest? request = _requests.FirstOrDefault(request => request.RequestId == id);

        if (request == null)
        {
            throw new KeyNotFoundException($"request id {id} is not found");
        }
        
        request.Approve();
    }

    public RequestStatisticsDto GetStatistics()
    { 
       return new RequestStatisticsDto(){
            TotalRequests=_requests.Count,
            SubmittedRequests =_requests.Count(request=>request.Status==EnumRequestStatus.Submitted),
            UnderReviewRequests = _requests.Count(request=>request.Status==EnumRequestStatus.UnderReview),
            ApprovedRequests = _requests.Count(request=>request.Status==EnumRequestStatus.Approved),
            RejectedRequests = _requests.Count(request=>request.Status==EnumRequestStatus.Rejected)
        };
    }

    private static RequestResponseDto MapToResponse(BenefitRequest request)
    {
        return new RequestResponseDto
        {
            RequestId = request.RequestId,
            ApplicantName = request.ApplicantName,
            Age = request.Age,
            MonthlySalary = request.MonthlySalary,
            Status = request.Status.ToString()
        };
    }

    private List<string> ApprovedApplicants()
    {
        return _requests.Where(request => request.Status.Equals(EnumRequestStatus.Approved))
        .Select(request => request.ApplicantName).OrderBy(name => name).ToList();
    }

}
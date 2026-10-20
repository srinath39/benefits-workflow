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

    public List<RequestResponseDto> GetAllRequests()
    {
        return _requests.Select(MapToResponse).ToList();
    }

    public List<String> ApprovedApplicants()
    {
        return _requests.Where(request=>request.Status.Equals(EnumRequestStatus.Approved))
        .Select(request=>request.ApplicantName).OrderBy(name=>name).ToList();
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

    private List<BenefitRequest> getAllApprovedRequest()
    {
        // var approvedRequests=new List<BenefitRequest>();
        // foreach(var benefitRequest in _requests){
        //     if (benefitRequest.Status.Equals(EnumRequestStatus.Approved))
        //     {
        //         approvedRequests.Add(benefitRequest);
        //     }
        // }
        // return approvedRequests;

        return _requests.Where(request => request.Status.Equals(EnumRequestStatus.Approved)).ToList();
    }
}
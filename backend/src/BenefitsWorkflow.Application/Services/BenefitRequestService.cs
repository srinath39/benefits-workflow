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
}
using BenefitsWorkflow.Application.DTOs;

namespace BenefitsWorkflow.Application.Interfaces;

public interface IBenefitRequestService
{
    RequestResponseDto CreateRequest(CreateRequestDto dto);

    List<RequestResponseDto> GetAllRequests();

    List<RequestResponseDto> GetApprovedRequests();

    RequestResponseDto GetARequestByRequestId(int id);

    void StartReview(int id);

    void ApproveReview(int id);

    RequestStatisticsDto GetStatistics();
}
using BenefitsWorkflow.Application.DTOs;

namespace BenefitsWorkflow.Application.Interfaces;

public interface IBenefitRequestService
{
    RequestResponseDto CreateRequest(CreateRequestDto dto);

    List<RequestResponseDto> GetAllRequests();
}
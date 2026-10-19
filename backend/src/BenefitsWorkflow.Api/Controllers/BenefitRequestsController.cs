using BenefitsWorkflow.Application.DTOs;
using BenefitsWorkflow.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BenefitsWorkflow.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BenefitRequestsController : ControllerBase
{
    private readonly IBenefitRequestService _service;

    public BenefitRequestsController(IBenefitRequestService service)
    {
        _service = service;
    }

    [HttpPost]
    public ActionResult<RequestResponseDto> Create(CreateRequestDto dto)
    {
        var result = _service.CreateRequest(dto);

        return CreatedAtAction(
            nameof(GetAll),
            new { id = result.RequestId },
            result);
    }

    [HttpGet]
    public ActionResult<List<RequestResponseDto>> GetAll()
    {
        return Ok(_service.GetAllRequests());
    }
}
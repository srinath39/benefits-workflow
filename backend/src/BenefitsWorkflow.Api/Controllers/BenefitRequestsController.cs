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
            nameof(GetARequestById),
            new { id = result.RequestId },
            result);
    }

    [HttpGet("{id:int}")]
    public ActionResult<RequestResponseDto> GetARequestById(int id)
    {
        return Ok(_service.GetARequestByRequestId(id));
    }

    [HttpGet]
    public ActionResult<List<RequestResponseDto>> GetAll()
    {
        return Ok(_service.GetAllRequests());
    }

    [HttpPut("{id:int}/start-review")]
    public IActionResult startAReviewById(int id)
    {
        _service.StartReview(id);
        return NoContent();
    }

    [HttpPut("{id:int}/approve")]
    public IActionResult ApproveArequestById(int id)
    {
        _service.ApproveReview(id);
        return NoContent();
    }

    [HttpGet("approved")]
    public ActionResult<List<RequestResponseDto>> GetAllApprovedRequests()
    {
        return Ok(_service.GetApprovedRequests());
    }

    [HttpGet("statistics")]
    public ActionResult<RequestStatisticsDto> GetBenefitRequestsStatistics()
    {
        return Ok(_service.GetStatistics());
    }

}
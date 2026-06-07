using BankMlekaBackendApp.DTOs;
using BankMlekaBackendApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankMlekaBackendApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BabyController : ControllerBase
{
    private readonly IBabyService _babyService;

    public BabyController(IBabyService babyService)
    {
        _babyService = babyService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateBaby([FromBody] CreateBabyInfoRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.FirstName) || string.IsNullOrWhiteSpace(request.LastName))
        {
            return BadRequest(new { Message = "First name and last name are required" });
        }

        try
        {
            var babyInfo = await _babyService.CreateBabyAsync(request);
            return CreatedAtAction(nameof(CreateBaby), new { id = babyInfo.Id }, babyInfo);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "An error occurred while creating the baby", Error = ex.Message });
        }
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetAllBabies()
    {
        try
        {
            var babies = await _babyService.GetAllBabiesAsync();
            return Ok(babies);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "An error occurred while retrieving babies", Error = ex.Message });
        }
    }
}

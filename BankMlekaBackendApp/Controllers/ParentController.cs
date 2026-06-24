using BankMlekaBackendApp.DTOs;
using BankMlekaBackendApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankMlekaBackendApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ParentController : ControllerBase
{
    private readonly IParentService _parentService;

    public ParentController(IParentService parentService)
    {
        _parentService = parentService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateParent([FromBody] CreateParentInfoRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.FirstName) || string.IsNullOrWhiteSpace(request.LastName))
        {
            return BadRequest(new { Message = "First name and last name are required" });
        }

        try
        {
            var parentInfo = await _parentService.CreateParentAsync(request);
            return CreatedAtAction(nameof(GetParentById), new { id = parentInfo.Id }, parentInfo);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "An error occurred while creating the parent", Error = ex.Message });
        }
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetAllParents()
    {
        try
        {
            var parents = await _parentService.GetAllParentsAsync();
            return Ok(parents);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "An error occurred while retrieving parents", Error = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetParentById(int id)
    {
        try
        {
            var parent = await _parentService.GetParentByIdAsync(id);
            if (parent == null)
            {
                return NotFound(new { Message = "Parent not found" });
            }

            return Ok(parent);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "An error occurred while retrieving the parent", Error = ex.Message });
        }
    }
}

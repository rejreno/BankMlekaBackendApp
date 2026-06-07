using BankMlekaBackendApp.DTOs;
using BankMlekaBackendApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankMlekaBackendApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] AuthLoginRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Login) || string.IsNullOrWhiteSpace(request.Password))
        {
            return Unauthorized(new AuthResponse { Message = "Invalid credentials" });
        }

        var valid = await _authService.ValidateCredentialsAsync(request.Login, request.Password);
        if (!valid)
            return Unauthorized(new AuthResponse { Message = "Invalid credentials" });

        return Ok(new AuthResponse { Message = "Login successful" });
    }
}

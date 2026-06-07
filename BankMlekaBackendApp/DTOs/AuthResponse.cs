namespace BankMlekaBackendApp.DTOs;

public class AuthResponse
{
    public string Message { get; set; } = null!;
    public bool IsAdmin { get; set; }
}

namespace BankMlekaBackendApp.DTOs;

public class CreateParentInfoRequest
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public bool? DonorStatus { get; set; }
    public string? Gender { get; set; }
    public string? Pesel { get; set; }
}

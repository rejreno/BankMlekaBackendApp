namespace BankMlekaBackendApp.DTOs;

public class CreateBabyInfoRequest
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public int? MotherId { get; set; }
    public int? FatherId { get; set; }
    public double? Weight { get; set; }
    public double? Height { get; set; }
    public string? Gender { get; set; }
}

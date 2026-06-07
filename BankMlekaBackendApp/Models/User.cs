using System.ComponentModel.DataAnnotations;

namespace BankMlekaBackendApp.Models;

public class User
{
    public int Id { get; set; }

    [Required]
    public string Login { get; set; } = null!;

    [Required]
    public string PasswordHash { get; set; } = null!;

    public bool IsAdmin { get; set; } = false;
}

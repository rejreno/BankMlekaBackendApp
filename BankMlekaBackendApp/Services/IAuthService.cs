using BankMlekaBackendApp.DTOs;
using BankMlekaBackendApp.Models;

namespace BankMlekaBackendApp.Services;

public interface IAuthService
{
    Task<User?> ValidateCredentialsAsync(string login, string password);
}

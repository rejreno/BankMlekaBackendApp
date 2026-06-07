using BankMlekaBackendApp.DTOs;

namespace BankMlekaBackendApp.Services;

public interface IAuthService
{
    Task<bool> ValidateCredentialsAsync(string login, string password);
}

using BankMlekaBackendApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BankMlekaBackendApp.Services;

public class AuthService : IAuthService
{
    private readonly BankMlekaContext _db;
    private readonly PasswordHasher<User> _hasher;

    public AuthService(BankMlekaContext db)
    {
        _db = db;
        _hasher = new PasswordHasher<User>();
    }

    public async Task<bool> ValidateCredentialsAsync(string login, string password)
    {
        var user = await _db.Set<User>().FirstOrDefaultAsync(u => u.Login == login);
        if (user == null)
            return false;

        var result = _hasher.VerifyHashedPassword(user, user.PasswordHash, password);
        return result == PasswordVerificationResult.Success || result == PasswordVerificationResult.SuccessRehashNeeded;
    }
}

using BankMlekaBackendApp.DTOs;
using BankMlekaBackendApp.Models;

namespace BankMlekaBackendApp.Services;

public interface IBabyService
{
    Task<BabyInfo> CreateBabyAsync(CreateBabyInfoRequest request);
    Task<List<BabyInfoResponse>> GetAllBabiesAsync();
}

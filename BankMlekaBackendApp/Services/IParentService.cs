using BankMlekaBackendApp.DTOs;
using BankMlekaBackendApp.Models;

namespace BankMlekaBackendApp.Services;

public interface IParentService
{
    Task<ParentInfo> CreateParentAsync(CreateParentInfoRequest request);
    Task<List<ParentInfo>> GetAllParentsAsync();
    Task<ParentInfo?> GetParentByIdAsync(int id);
}

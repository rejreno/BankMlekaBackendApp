using BankMlekaBackendApp.DTOs;
using BankMlekaBackendApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BankMlekaBackendApp.Services;

public class ParentService : IParentService
{
    private readonly BankMlekaContext _db;

    public ParentService(BankMlekaContext db)
    {
        _db = db;
    }

    public async Task<ParentInfo> CreateParentAsync(CreateParentInfoRequest request)
    {
        var parentInfo = new ParentInfo
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            DonorStatus = request.DonorStatus,
            Gender = request.Gender,
            Pesel = request.Pesel
        };

        _db.ParentInfos.Add(parentInfo);
        await _db.SaveChangesAsync();

        return parentInfo;
    }

    public async Task<List<ParentInfo>> GetAllParentsAsync()
    {
        return await _db.ParentInfos.ToListAsync();
    }

    public async Task<ParentInfo?> GetParentByIdAsync(int id)
    {
        return await _db.ParentInfos.FindAsync(id);
    }
}

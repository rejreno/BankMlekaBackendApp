using BankMlekaBackendApp.DTOs;
using BankMlekaBackendApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BankMlekaBackendApp.Services;

public class BabyService : IBabyService
{
    private readonly BankMlekaContext _db;

    public BabyService(BankMlekaContext db)
    {
        _db = db;
    }

    public async Task<BabyInfo> CreateBabyAsync(CreateBabyInfoRequest request)
    {
        var babyInfo = new BabyInfo
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            MotherId = request.MotherId,
            FatherId = request.FatherId,
            Weight = request.Weight,
            Height = request.Height,
            Gender = request.Gender
        };

        _db.BabyInfos.Add(babyInfo);
        await _db.SaveChangesAsync();

        return babyInfo;
    }

    public async Task<List<BabyInfoResponse>> GetAllBabiesAsync()
    {
        return await _db.BabyInfos
            .Select(b => new BabyInfoResponse
            {
                Id = b.Id,
                FirstName = b.FirstName,
                LastName = b.LastName,
                Gender = b.Gender
            })
            .ToListAsync();
    }
}

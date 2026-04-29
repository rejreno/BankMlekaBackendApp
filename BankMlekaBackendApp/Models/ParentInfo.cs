using System;
using System.Collections.Generic;

namespace BankMlekaBackendApp.Models;

public partial class ParentInfo
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public bool? DonorStatus { get; set; }

    public string? Gender { get; set; }

    public string? Pesel { get; set; }

    public virtual ICollection<BabyInfo> BabyInfoFathers { get; set; } = new List<BabyInfo>();

    public virtual ICollection<BabyInfo> BabyInfoMothers { get; set; } = new List<BabyInfo>();

    public virtual ICollection<Bedding> Beddings { get; set; } = new List<Bedding>();

    public virtual ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();

    public virtual ICollection<MilkInfo> MilkInfos { get; set; } = new List<MilkInfo>();

    public virtual ICollection<MilkTest> MilkTests { get; set; } = new List<MilkTest>();
}

using System;
using System.Collections.Generic;

namespace BankMlekaBackendApp.Models;

public partial class MilkTest
{
    public int Id { get; set; }

    public DateOnly Date { get; set; }

    public int DonorId { get; set; }

    public double Carbs { get; set; }

    public double Calories { get; set; }

    public double Fat { get; set; }

    public double Protein { get; set; }

    public virtual ParentInfo Donor { get; set; } = null!;

    public virtual ICollection<MilkInfo> MilkInfos { get; set; } = new List<MilkInfo>();
}

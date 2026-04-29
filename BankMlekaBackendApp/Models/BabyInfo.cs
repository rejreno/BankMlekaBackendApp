using System;
using System.Collections.Generic;

namespace BankMlekaBackendApp.Models;

public partial class BabyInfo
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int? MotherId { get; set; }

    public int? FatherId { get; set; }

    public double? Weight { get; set; }

    public double? Height { get; set; }

    public string? Gender { get; set; }

    public string? AvatarName { get; set; }

    public string? Pesel { get; set; }

    public virtual ICollection<BabyUpdate> BabyUpdates { get; set; } = new List<BabyUpdate>();

    public virtual ICollection<Bedding> Beddings { get; set; } = new List<Bedding>();

    public virtual ICollection<Consumption> Consumptions { get; set; } = new List<Consumption>();

    public virtual ParentInfo? Father { get; set; }

    public virtual ParentInfo? Mother { get; set; }
}

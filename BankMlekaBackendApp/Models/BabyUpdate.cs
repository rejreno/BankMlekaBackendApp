using System;
using System.Collections.Generic;

namespace BankMlekaBackendApp.Models;

public partial class BabyUpdate
{
    public int Id { get; set; }

    public int BabyId { get; set; }

    public double? Height { get; set; }

    public double? Weight { get; set; }

    public double? Consumption { get; set; }

    public DateOnly? UpdateDate { get; set; }

    public virtual BabyInfo Baby { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace BankMlekaBackendApp.Models;

public partial class Consumption
{
    public int Id { get; set; }

    public int BabyId { get; set; }

    public int MilkId { get; set; }

    public int Amount { get; set; }

    public DateTime Timestamp { get; set; }

    public virtual BabyInfo Baby { get; set; } = null!;

    public virtual MilkInfo Milk { get; set; } = null!;
}

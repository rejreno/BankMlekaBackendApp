using System;
using System.Collections.Generic;

namespace BankMlekaBackendApp.Models;

public partial class Delivery
{
    public int Id { get; set; }

    public int ParentId { get; set; }

    public int DeviceId { get; set; }

    public int? MilkId { get; set; }

    public int Amount { get; set; }

    public DateTime ExpectedDate { get; set; }

    public DateTime? AcceptanceDate { get; set; }

    public string? TransportType { get; set; }

    public virtual Device Device { get; set; } = null!;

    public virtual MilkInfo? Milk { get; set; }

    public virtual ParentInfo Parent { get; set; } = null!;

    public virtual ICollection<Rented> Renteds { get; set; } = new List<Rented>();
}

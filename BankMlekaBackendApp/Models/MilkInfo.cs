using System;
using System.Collections.Generic;

namespace BankMlekaBackendApp.Models;

public partial class MilkInfo
{
    public int Id { get; set; }

    public int DonorId { get; set; }

    public DateTime AcceptanceDate { get; set; }

    public DateTime TerminationDate { get; set; }

    public string Storage { get; set; } = null!;

    public int Volume { get; set; }

    public int MaxVolume { get; set; }

    public int BottleId { get; set; }

    public int LastTestId { get; set; }

    public virtual ICollection<Consumption> Consumptions { get; set; } = new List<Consumption>();

    public virtual ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();

    public virtual ParentInfo Donor { get; set; } = null!;

    public virtual MilkTest LastTest { get; set; } = null!;
}

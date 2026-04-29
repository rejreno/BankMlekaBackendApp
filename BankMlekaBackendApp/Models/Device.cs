using System;
using System.Collections.Generic;

namespace BankMlekaBackendApp.Models;

public partial class Device
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Type { get; set; } = null!;

    public int MaxAmount { get; set; }

    public virtual ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();

    public virtual ICollection<Rented> Renteds { get; set; } = new List<Rented>();
}

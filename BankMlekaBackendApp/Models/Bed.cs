using System;
using System.Collections.Generic;

namespace BankMlekaBackendApp.Models;

public partial class Bed
{
    public int Id { get; set; }

    public int Floor { get; set; }

    public int Room { get; set; }

    public int BedNumber { get; set; }

    public virtual ICollection<Bedding> Beddings { get; set; } = new List<Bedding>();
}

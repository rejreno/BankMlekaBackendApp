using System;
using System.Collections.Generic;

namespace BankMlekaBackendApp.Models;

public partial class Bedding
{
    public int Id { get; set; }

    public int BedId { get; set; }

    public int BabyId { get; set; }

    public int MotherId { get; set; }

    public string? Note { get; set; }

    public DateOnly AssignDate { get; set; }

    public DateOnly? ReleaseDate { get; set; }

    public virtual BabyInfo Baby { get; set; } = null!;

    public virtual Bed Bed { get; set; } = null!;

    public virtual ParentInfo Mother { get; set; } = null!;
}
